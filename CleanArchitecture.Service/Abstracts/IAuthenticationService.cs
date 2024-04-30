using CleanArchitecture.Data.Entities.Identity;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> GetGWTToken(User user);
    }
}
