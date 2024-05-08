using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Users.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        #endregion

        #region CTOR
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper,
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService,
            IUserService userService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _userService = userService;
        }
        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            //Mapping
            var identityUser = _mapper.Map<User>(request);
            var createResult = await _userService.AddUserAsync(identityUser, request.Password);
            switch (createResult)
            {
                case "EmailIsExist":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.EmailIsExist]);
                case "UserNameIsExist":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UserNameIsExist]);
                case "ErrorInCreateUser":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddUser]);
                case "FailedSendEmail":
                    return BadRequest<string>("FailedSendEmail");
                case "Failed":
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.TryToRegisterAgain]);
                case "Success": return Created("");
                default:
                    return BadRequest<string>(createResult);



            }




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
