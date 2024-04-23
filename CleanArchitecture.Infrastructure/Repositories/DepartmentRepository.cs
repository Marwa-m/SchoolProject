using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        #region Fields

        private readonly DbSet<Department> _department;
        #endregion

        #region Ctor
        public DepartmentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _department = dBContext.Set<Department>();
        }
        #endregion

        #region Handles function
        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _department.Include(x => x.Instructor).ToListAsync();
        }

        #endregion
    }

}
