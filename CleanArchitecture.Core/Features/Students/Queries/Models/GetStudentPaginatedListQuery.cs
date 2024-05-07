using CleanArchitecture.Core.Features.Students.Queries.Results;
using CleanArchitecture.Core.Wrapper;
using CleanArchitecture.Data.Enums;
using MediatR;

namespace CleanArchitecture.Core.Features.Students.Queries.Models;

public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public StudentOrderEnum OrderBy { get; set; }
    public string? Search { get; set; }

}
