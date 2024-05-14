using CleanArchitecture.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Core.Features.Instructors.Commands.Models
{
    public class AddInstructorCommand : IRequest<Response<string>>
    {
        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Position { get; set; }

        public string? Address { get; set; }

        public int? SupervisorID { get; set; }
        public double? Salary { get; set; }
        public int DID { get; set; }
        public IFormFile? Image { get; set; }

    }
}
