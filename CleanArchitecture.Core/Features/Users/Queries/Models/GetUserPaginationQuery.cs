using CleanArchitecture.Core.Features.Users.Queries.Results;
using CleanArchitecture.Core.Wrapper;
using MediatR;

namespace CleanArchitecture.Core.Features.Users.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
