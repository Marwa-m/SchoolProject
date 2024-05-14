using CleanArchitecture.Data.Entities.Procedures;
using CleanArchitecture.Infrastructure.Abstracts.Procedures;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using StoredProcedureEFCore;

namespace CleanArchitecture.Infrastructure.Repositories.Procedures
{
    public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
    {
        #region Fields
        private readonly ApplicationDBContext _dBContext;

        #endregion

        #region Ctor
        public DepartmentStudentCountProcRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }


        #endregion

        #region Handles function

        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProc(DepartmentStudentCountProcParams parameters)
        {

            var rows = new List<DepartmentStudentCountProc>();
            await _dBContext.LoadStoredProc(nameof(DepartmentStudentCountProc))
                   .AddParam("@DID", parameters.DID)
                   .ExecAsync(async r => rows = await r.ToListAsync<DepartmentStudentCountProc>());
            return rows;
        }
        #endregion
    }
}
