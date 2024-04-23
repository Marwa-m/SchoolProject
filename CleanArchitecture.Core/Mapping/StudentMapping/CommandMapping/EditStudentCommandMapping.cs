using CleanArchitecture.Core.Features.Students.Commands.Models;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Student>()
    .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentID));

        }
    }

}
