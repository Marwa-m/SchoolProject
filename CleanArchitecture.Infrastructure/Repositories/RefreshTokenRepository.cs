using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {

        #region Fields

        private readonly DbSet<UserRefreshToken> _userRefreshTokens;
        #endregion

        #region Ctor
        public RefreshTokenRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
        #endregion

        #region Handles function

        #endregion
    }
}
