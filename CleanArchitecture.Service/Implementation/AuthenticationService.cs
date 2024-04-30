using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Helper;
using CleanArchitecture.Service.Abstracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;

        #endregion

        #region ctor
        public AuthenticationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        #endregion

        #region Methods
        public Task<string> GetGWTToken(User user)
        {
            var claims = new List<Claim>() {
            new Claim(nameof(UserClaimsModel.UserName), user.UserName),
            new Claim(nameof(UserClaimsModel.Email), user.Email),
            new Claim(nameof(UserClaimsModel.PhoneNumber), user.PhoneNumber),
            };

            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,

                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Task.FromResult(accessToken);
        }
        #endregion

    }
}
