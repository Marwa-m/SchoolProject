using CleanArchitecture.Core.Bases;
using CleanArchitecture.Data.DTOs;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
