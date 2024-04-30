using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authentication.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
            IRequestHandler<SignInCommand, Response<string>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;

        #endregion

        #region CTOR
        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }


        #endregion

        #region Methods
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);

            }
            //Generate JWTToken
            var accessToken = await _authenticationService.GetGWTToken(user);
            if (accessToken == null)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            }
            return Success(accessToken);
        }
        #endregion
    }
}
