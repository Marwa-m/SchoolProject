using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}
