using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Departments.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentStudentCountByIdQuery : IRequest<Response<GetDepartmentStudentCountByIdResult>>
    {
        public int DID { get; set; }
    }
}
