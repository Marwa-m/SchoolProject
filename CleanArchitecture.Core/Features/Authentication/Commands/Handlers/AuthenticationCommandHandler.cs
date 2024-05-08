using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authentication.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Results;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
            IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
            IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>

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
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.UserNameIsNotExist]);
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.PasswordNotCorrect]);

            }
            if (!user.EmailConfirmed)
            {
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailNotConfirmed]);

            }
            //Generate JWTToken
            var gwtResult = await _authenticationService.GetGWTToken(user);
            if (gwtResult == null)
            {
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.BadRequest]);
            }
            return Success(gwtResult);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = _authenticationService.ReadJWTToken(request.AccessToken);
            var (userId, expiryDate) = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (userId)
            {
                case "Error in Algorithm":
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.AlgorithmIsWrong]);
                case "Token is not expired":
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.TokenIsNotExpired]);
                case "RefreshToken is Not Found":
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case "RefreshToken is expired":
                    return Unauthorized<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.RefreshTokenIsExpired]);
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);

            }
            var result = await _authenticationService.GetRefreshToken(user, jwtToken, request.RefreshToken, expiryDate);
            return Success(result);
        }
        #endregion
    }
}
