using CleanArchitecture.Data.Entities.Procedures;

namespace CleanArchitecture.Infrastructure.Abstracts.Procedures
{
    public interface IDepartmentStudentCountProcRepository
    {
        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProc(DepartmentStudentCountProcParams parameters);
    }
}
