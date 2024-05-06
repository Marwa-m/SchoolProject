using CleanArchitecture.Data.DTOs;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;

        #endregion

        #region CTOR
        public AuthorizationService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        #endregion

        #region Methods
        public async Task<string> AddRoleAsync(string roleName)
        {
            var identityRole = new Role()
            {
                Name = roleName,
            };
            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return "Succeeded";
            }
            else return "Failed";
        }

        public async Task<string> EditRoleAsync(EditRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id.ToString());
            if (role == null)
            {
                return "NotFound";
            }
            role.Name = request.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return "Succeeded";
            }
            else return result.Errors.FirstOrDefault().Description;
        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
        #endregion

    }
}
