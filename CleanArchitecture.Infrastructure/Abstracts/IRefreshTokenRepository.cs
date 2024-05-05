using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Infrastructure.Bases;

namespace CleanArchitecture.Infrastructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
