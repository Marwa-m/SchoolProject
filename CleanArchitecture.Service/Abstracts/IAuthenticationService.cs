using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Helper;
using System.IdentityModel.Tokens.Jwt;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<JwtAuthResult> GetGWTToken(User user);
        public Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, string refreshToken, DateTime? expiryDate);
        public Task<string> ValidateToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
    }
}
