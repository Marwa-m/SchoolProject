using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResult>>
    {
        public GetRoleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
