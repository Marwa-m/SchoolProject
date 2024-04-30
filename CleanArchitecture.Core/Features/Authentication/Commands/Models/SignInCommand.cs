using CleanArchitecture.Core.Bases;
using MediatR;

namespace CleanArchitecture.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
