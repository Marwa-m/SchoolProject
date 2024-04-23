using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Students.Queries.Results;
using MediatR;

namespace CleanArchitecture.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
