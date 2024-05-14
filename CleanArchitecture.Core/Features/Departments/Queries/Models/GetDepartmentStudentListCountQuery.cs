using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Departments.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentStudentListCountQuery : IRequest<Response<List<GetDepartmentStudentListCountResult>>>
    {
    }
}
