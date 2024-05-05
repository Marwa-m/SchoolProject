using CleanArchitecture.Core.Bases;
using CleanArchitecture.Data.Helper;
using MediatR;

namespace CleanArchitecture.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
