using CleanArchitecture.Core.Features.Students.Commands.Models;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.StudentMapping
{

    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Student>()
    .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentID));

        }
    }

}
