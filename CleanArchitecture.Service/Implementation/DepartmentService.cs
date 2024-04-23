using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;

        #endregion
        #region Ctor
        public DepartmentService(IDepartmentRepository departmentRepository
                                )
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        #region Methods
        public async Task<Department> GetDepartmentByIdAsync(int Id)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(Id))
                                   .Include(x => x.DepartmentSubjects).ThenInclude(y => y.Subject)
                                   .Include(x => x.Instructors)
                                   .Include(x => x.Instructor)
                                   .FirstOrDefaultAsync();

            return department;
        }
        #endregion

    }
}
