using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Entities.Procedures;
using CleanArchitecture.Data.Entities.Views;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Abstracts.Procedures;
using CleanArchitecture.Infrastructure.Abstracts.Views;
using CleanArchitecture.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IViewRepository<ViewDepartment> _viewRepository;
        private readonly IDepartmentStudentCountProcRepository _procRepository;

        #endregion
        #region Ctor
        public DepartmentService(IDepartmentRepository departmentRepository,
                                IViewRepository<ViewDepartment> viewRepository,
                                IDepartmentStudentCountProcRepository procRepository)
        {
            _departmentRepository = departmentRepository;
            _viewRepository = viewRepository;
            _procRepository = procRepository;
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

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProc(DepartmentStudentCountProcParams parameters)
        {
            return await _procRepository.GetDepartmentStudentCountProc(parameters);
        }

        public async Task<List<ViewDepartment>> GetViewDepartmentDataAsync()
        {
            var viewDepartment = await _viewRepository.GetTableNoTracking().ToListAsync();
            return viewDepartment;
        }

        public async Task<bool> IsDepartmentExist(int Id)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(Id));
        }


        #endregion

    }
}
