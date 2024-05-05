using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Helper;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;

        //  private readonly ConcurrentDictionary<string, RefreshToken> _userRefreshToken;

        #endregion

        #region ctor
        public AuthenticationService(JwtSettings jwtSettings,
            IRefreshTokenRepository refreshTokenRepository,
            UserManager<User> userManager)
        {
            _jwtSettings = jwtSettings;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            //  _userRefreshToken = new ConcurrentDictionary<string, RefreshToken>();

        }
        #endregion
        #region Local Method
        private static List<Claim> GetClaims(User user)
        {
            return new List<Claim>() {
            new Claim(nameof(UserClaimsModel.Id), user.Id.ToString()),
            new Claim(nameof(UserClaimsModel.UserName), user.UserName),
            new Claim(nameof(UserClaimsModel.Email), user.Email),
            new Claim(nameof(UserClaimsModel.PhoneNumber), user.PhoneNumber),
            };
        }
        public RefreshToken GetRefreshToken(User user)
        {
            var refreshToken = new RefreshToken()
            {
                ExpireAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = user.UserName,
                TokenString = GenerateRefreshToken()
            };
            // _userRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);
            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private (JwtSecurityToken, string) GenerateJWToken(User user)
        {

            List<Claim> claims = GetClaims(user);

            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,

                expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return (jwtToken, accessToken);
        }


        #endregion
        #region Methods
        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);

            return response;
        }
        public async Task<JwtAuthResult> GetGWTToken(User user)
        {
            (JwtSecurityToken jwtToken, string accessToken) = GenerateJWToken(user);
            RefreshToken refreshToken = GetRefreshToken(user);
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsRevoked = false,
                IsUsed = true,
                JwtId = jwtToken.Id,
                RefreshToken = refreshToken.TokenString,
                Token = accessToken,
                UserId = user.Id

            };
            var userRefreshObject = await _refreshTokenRepository.AddAsync(userRefreshToken);
            if (userRefreshObject == null)
            {

            }
            return new JwtAuthResult
            {
                AccessToken = accessToken,
                refreshToken = refreshToken
            };
        }

        public async Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, string refreshToken, DateTime? expiryDate)
        {


            var (jwtSecurityToken, newToken) = GenerateJWToken(user);

            var response = new JwtAuthResult
            {
                AccessToken = newToken
            };
            var RefreshTokenResult = new RefreshToken
            {
                ExpireAt = expiryDate.Value,
                UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.UserName)).Value,
                TokenString = refreshToken
            };
            response.refreshToken = RefreshTokenResult;
            return response;
        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "invalid token";
                }
                return "Not Expired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("Error in Algorithm", null);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("Token is not expired", null);
            }
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimsModel.Id)).Value;
            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking()
                                            .FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                                    x.RefreshToken == refreshToken &&
                                                                   x.UserId == int.Parse(userId));
            if (userRefreshToken == null)
            {
                return ("RefreshToken is Not Found", null);

            }
            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("RefreshToken is expired", null);
            }
            return (userId, userRefreshToken.ExpiryDate);
        }



        #endregion

    }
}
