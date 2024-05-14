using AutoMapper;

namespace CleanArchitecture.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
            GetDepartmentStudentListCountMappping();
            GetDepartmentStudentCountByIdMapping();
        }
    }
}
