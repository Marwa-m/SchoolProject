using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<User> GetUserAsync();
        public int GetUserId();

        public Task<List<string>> GetUserRolesAsync();

    }
}
