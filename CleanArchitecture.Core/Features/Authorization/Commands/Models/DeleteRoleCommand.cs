using CleanArchitecture.Core.Bases;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public DeleteRoleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
