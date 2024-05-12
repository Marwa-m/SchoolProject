using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Results;
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
        public Task<string> ConfirmEmail(int? userId, string? code);
        public Task<string> SendResetPasswordCode(string email);
        public Task<string> ConfirmResetPassword(string email, string code);
        public Task<string> ResetPassword(string email, string password);
    }
}
