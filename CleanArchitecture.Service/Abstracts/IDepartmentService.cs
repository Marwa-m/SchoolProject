using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int Id);
    }
}
