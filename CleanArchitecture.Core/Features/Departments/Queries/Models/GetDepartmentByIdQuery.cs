using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Departments.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int? StudentPageNumber { get; set; }
        public int? StudentPageSize { get; set; }


    }
}
