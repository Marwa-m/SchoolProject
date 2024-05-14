using CleanArchitecture.Core.Features.Departments.Queries.Results;
using CleanArchitecture.Data.Entities.Views;

namespace CleanArchitecture.Core.Mapping.DepartmentMapping
{
    partial class DepartmentProfile
    {
        public void GetDepartmentStudentListCountMappping()
        {
            CreateMap<ViewDepartment, GetDepartmentStudentListCountResult>()
   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
   .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount));


        }
    }
}
