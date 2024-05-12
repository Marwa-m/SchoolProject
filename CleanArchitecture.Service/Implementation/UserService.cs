using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Service.Implementation
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly ApplicationDBContext _dBContext;
        private readonly IUrlHelper _urlHelper;

        #endregion

        #region CTOR
        public UserService(UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor,
            IEmailService emailService,
            ApplicationDBContext dBContext,
            IUrlHelper urlHelper)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            _dBContext = dBContext;
            _urlHelper = urlHelper;
        }
        #endregion

        #region Methods
        public async Task<string> AddUserAsync(User user, string password)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                //if email is exist return an error message
                var isExistuser = await _userManager.FindByEmailAsync(user.Email);
                if (isExistuser != null)
                    return "EmailIsExist";
                isExistuser = await _userManager.FindByNameAsync(user.UserName);
                if (isExistuser != null)
                    return "UserNameIsExist";
                var createResult = await _userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                {
                    return createResult.Errors.FirstOrDefault().Description;
                }

                await _userManager.AddToRoleAsync(user, "User");
                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var requestAccessor = _httpContextAccessor.HttpContext.Request;
                //var returnUrl = $"{requestAccessor.Scheme}://{requestAccessor.Host}/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                var returnUrl = $"To Confirm Email, please click to the link: <a href=' {requestAccessor.Scheme}://{requestAccessor.Host}";
                returnUrl += _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = user.Id, code = code }) + "'></a>";
                //Message body
                var sendEmailResult = await _emailService.SendEmail(user.Email, returnUrl, "Confirm Email");
                if (sendEmailResult != "Success")
                {
                    return "FailedSendEmail";
                }
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
        #endregion

    }
}
