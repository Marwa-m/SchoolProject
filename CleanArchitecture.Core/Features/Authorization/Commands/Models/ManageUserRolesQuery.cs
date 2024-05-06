using CleanArchitecture.Core.Bases;
using CleanArchitecture.Data.DTOs;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}
