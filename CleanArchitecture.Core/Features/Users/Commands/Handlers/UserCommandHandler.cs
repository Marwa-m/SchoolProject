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
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>
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
            var userEmailExist = _userManager.Users.FirstOrDefault(x => x.Email == userExist.Email && x.Id != userExist.Id);
            if (userEmailExist != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
            var userNameExist = _userManager.Users.FirstOrDefault(x => x.UserName == userExist.UserName && x.Id != userExist.Id);
            if (userNameExist != null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
            var mapperUser = _mapper.Map(request, userExist);

            var resultMessage = await _userManager.UpdateAsync(mapperUser);
            if (!resultMessage.Succeeded)
                return BadRequest<string>(resultMessage.Errors.FirstOrDefault().Description);
            else
                return Success(_stringLocalizer[SharedResourcesKeys.Updated].ToString());
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByIdAsync(request.Id.ToString());
            if (userExist == null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var resultMessage = await _userManager.DeleteAsync(userExist);
            if (!resultMessage.Succeeded)
                return BadRequest<string>(resultMessage.Errors.FirstOrDefault().Description);
            else
                return Success(_stringLocalizer[SharedResourcesKeys.Deleted].ToString());
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userManager.FindByIdAsync(request.Id.ToString());
            if (userExist == null)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            var result = await _userManager.ChangePasswordAsync(userExist, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
                return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            else
                return Success(_stringLocalizer[SharedResourcesKeys.Success].ToString());
        }

        #endregion

    }
}
