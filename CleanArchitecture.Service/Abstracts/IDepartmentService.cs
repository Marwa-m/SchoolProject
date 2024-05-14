using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Entities.Procedures;
using CleanArchitecture.Data.Entities.Views;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int Id);
        public Task<bool> IsDepartmentExist(int Id);
        public Task<List<ViewDepartment>> GetViewDepartmentDataAsync();

        public Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProc(DepartmentStudentCountProcParams parameters);


    }
}
