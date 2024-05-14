using CleanArchitecture.Core.Features.Departments.Queries.Models;
using CleanArchitecture.Core.Features.Departments.Queries.Results;
using CleanArchitecture.Data.Entities.Procedures;

namespace CleanArchitecture.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentStudentCountByIdMapping()
        {
            CreateMap<GetDepartmentStudentCountByIdQuery, DepartmentStudentCountProcParams>();
            CreateMap<DepartmentStudentCountProc, GetDepartmentStudentCountByIdResult>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
             .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.StudentCount));

        }
    }
}
