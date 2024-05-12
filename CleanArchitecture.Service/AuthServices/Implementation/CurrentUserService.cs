using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Helper;
using CleanArchitecture.Service.AuthServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Service.AuthServices.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        #endregion

        #region CTOR
        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task<User> GetUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new UnauthorizedAccessException("");
            }
            return user;
        }

        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == nameof(UserClaimsModel.Id)).Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException(userId);
            }
            return int.Parse(userId);
        }

        public async Task<List<string>> GetUserRolesAsync()
        {
            var user = await GetUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();

        }
        #endregion
    }


}
