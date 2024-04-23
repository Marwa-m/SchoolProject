using CleanArchitecture.Core.Features.Students.Queries.Results;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.StudentMapping
{

    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentResponse>()
    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

        }
    }
}
