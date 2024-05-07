using CleanArchitecture.Data.DTOs;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Helper;
using CleanArchitecture.Data.Results;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static CleanArchitecture.Data.Results.ManageUserClaimsResult;

namespace CleanArchitecture.Service.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _dBContext;

        #endregion

        #region CTOR
        public AuthorizationService(RoleManager<Role> roleManager,
                                    UserManager<User> userManager,
                                    ApplicationDBContext dBContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dBContext = dBContext;
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

        public async Task<ManageUserRolesResult> GetUserRoles(User user)
        {
            var response = new ManageUserRolesResult();
            response.UserId = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                Roles roles1 = new Roles
                {
                    Name = role.Name,
                    Id = role.Id
                };
                if (userRoles.Contains(role.Name))
                {
                    roles1.HasRole = true;
                }
                response.Roles.Add(roles1);
            }

            return response;
        }

        public async Task<ManageUserRolesResult> GetUserRoles(User user)
        {
            var response = new ManageUserRolesResult();
            response.UserId = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                Roles roles1 = new Roles
                {
                    Name = role.Name,
                    Id = role.Id
                };
                if (userRoles.Contains(role.Name))
                {
                    roles1.HasRole = true;
                }
                response.Roles.Add(roles1);
            }

            return response;
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

        public async Task<string> UpdateUserRoles(UpdateUserRoleRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return "UserNotFound";
            var userOldRoles = await _userManager.GetRolesAsync(user);
            var transact = await _dBContext.Database.BeginTransactionAsync();
            try
            {


                var removeRoles = await _userManager.RemoveFromRolesAsync(user, userOldRoles);
                if (!removeRoles.Succeeded)
                {
                    return "FailedToRemoveOldRoles";
                }
                var selectedRoles = request.Roles.Where(x => x.HasRole == true).Select(x => x.Name);
                var result = await _userManager.AddToRolesAsync(user, selectedRoles);
                if (!result.Succeeded) return "FailedToAddNewRoles";

                await transact.CommitAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdate";
            }

        }

        //Manage User Claims
        public async Task<ManageUserClaimsResult> GetUserClaims(User user)
        {
            var response = new ManageUserClaimsResult();
            response.UserId = user.Id;

            var userClaims = await _userManager.GetClaimsAsync(user);
            foreach (var claim in ClaimStore.Claims)
            {
                UserClaim claim1 = new UserClaim(claim.Type);

                if (userClaims.Any(x => x.Type == claim.Type))
                {
                    claim1.Value = true;
                }
                response.UserClaims.Add(claim1);
            }

            return response;
        }

        public async Task<string> UpdateUserClaims(UpdateUserClaimRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return "UserNotFound";
            var userOldClaims = await _userManager.GetClaimsAsync(user);
            var transact = await _dBContext.Database.BeginTransactionAsync();
            try
            {


                var removeClaims = await _userManager.RemoveClaimsAsync(user, userOldClaims);
                if (!removeClaims.Succeeded)
                {
                    return "FailedToRemoveOldClaims";
                }
                var selectedClaims = request.UserClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));
                var result = await _userManager.AddClaimsAsync(user, selectedClaims);
                if (!result.Succeeded) return "FailedToAddNewClaims";

                await transact.CommitAsync();
                return "Success";

            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "FailedToUpdate";
            }
        }

        #endregion

    }
}
