using CleanArchitecture.Core.Bases;
using MediatR;

namespace CleanArchitecture.Core.Features.Instructors.Queries.Models
{
    public class GetSummationSalaryOfInstructorQuery : IRequest<Response<decimal>>
    {
    }
}
