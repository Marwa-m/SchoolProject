using CleanArchitecture.Core.Features.Students.Queries.Results;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentPaginationMapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
    .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentID))
    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        }
    }
}
