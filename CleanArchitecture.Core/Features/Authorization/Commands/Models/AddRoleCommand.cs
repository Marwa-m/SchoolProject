using CleanArchitecture.Core.Bases;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
