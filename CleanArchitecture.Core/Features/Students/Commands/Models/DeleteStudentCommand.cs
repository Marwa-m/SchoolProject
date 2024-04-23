using CleanArchitecture.Core.Bases;
using MediatR;

namespace CleanArchitecture.Core.Features.Students.Commands.Models
{

    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
