using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Users.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                    IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region CTOR
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper,
            UserManager<User> userManager) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //if email is exist return an error message
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
            //Mapping
            var identityUser = _mapper.Map<User>(request);
            var createResult = await _userManager.CreateAsync(identityUser, request.Password);
            if (!createResult.Succeeded)
            {
                return BadRequest<string>(createResult.Errors.FirstOrDefault().Description);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByIdAsync(request.Id);
            if (userExist == null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var mapperUser = _mapper.Map(request, userExist);

            var resultMessage = await _userManager.UpdateAsync(mapperUser);
            if (!resultMessage.Succeeded)
                return BadRequest<string>(resultMessage.Errors.FirstOrDefault().Description);
            else
                return Success("");
        }

        #endregion

    }
}
