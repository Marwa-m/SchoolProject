using CleanArchitecture.Core.Features.Students.Commands.Models;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.StudentMapping
{

    public partial class StudentProfile
    {
        public void DeleteStudentCommandMapping()
        {
            CreateMap<DeleteStudentCommand, Student>()
    .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.ID));

        }
    }
}
