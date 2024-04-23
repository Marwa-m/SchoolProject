using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Students.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
