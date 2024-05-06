using CleanArchitecture.Data.DTOs;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        #endregion

        #region CTOR
        public AuthorizationService(RoleManager<Role> roleManager,
                                    UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        public async Task<string> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return "NotFound";
            }
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            if (users != null && users.Count > 0) return "This role is used";
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return "Succeeded";
            }
            else return result.Errors.FirstOrDefault().Description;
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

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();

        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<bool> IsRoleExistById(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null) return false;
            return true;

        }
        #endregion

    }
}
