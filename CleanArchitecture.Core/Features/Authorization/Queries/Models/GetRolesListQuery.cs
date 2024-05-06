using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Authorization.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Authorization.Queries.Models
{
    public class GetRolesListQuery : IRequest<Response<List<GetRolesListReponse>>>
    {

    }
}
