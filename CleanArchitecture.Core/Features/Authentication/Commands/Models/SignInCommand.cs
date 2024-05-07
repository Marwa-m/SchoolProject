using CleanArchitecture.Core.Bases;
using CleanArchitecture.Data.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
