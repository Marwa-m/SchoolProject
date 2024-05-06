using CleanArchitecture.Data.DTOs;
using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IAuthorizationService
    {

        public Task<List<Role>> GetRolesAsync();
        public Task<Role> GetRoleByIdAsync(int id);
        public Task<string> AddRoleAsync(string roleName);

        public Task<string> DeleteRoleAsync(int id);

        public Task<string> EditRoleAsync(EditRoleRequest request);

        public Task<bool> IsRoleExist(string roleName);
        public Task<bool> IsRoleExistById(int id);

    }
}
