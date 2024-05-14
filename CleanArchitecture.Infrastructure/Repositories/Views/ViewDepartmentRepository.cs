using CleanArchitecture.Data.Entities.Views;
using CleanArchitecture.Infrastructure.Abstracts.Views;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories.Views
{
    public class ViewDepartmentRepository : GenericRepositoryAsync<ViewDepartment>, IViewRepository<ViewDepartment>
    {
        #region Fields

        private readonly DbSet<ViewDepartment> _viewDepartment;
        #endregion

        #region Ctor
        public ViewDepartmentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _viewDepartment = dBContext.Set<ViewDepartment>();
        }
        #endregion

        #region Handles function
        public async Task<List<ViewDepartment>> GetAllDepartmentsAsync()
        {
            return await _viewDepartment.ToListAsync();
        }

        #endregion
    }
}
