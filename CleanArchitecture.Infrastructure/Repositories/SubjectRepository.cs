using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields

        private readonly DbSet<Subject> _subject;
        #endregion

        #region Ctor
        public SubjectRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _subject = dBContext.Set<Subject>();
        }
        #endregion

        #region Handles function
        public async Task<List<Subject>> GetAllDepartmentsAsync()
        {
            return await _subject.ToListAsync();
        }

        #endregion
    }

}
