using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields

        private readonly DbSet<Instructor> _instructor;
        #endregion

        #region Ctor
        public InstructorRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _instructor = dBContext.Set<Instructor>();
        }
        #endregion

        #region Handles function
        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructor.ToListAsync();
        }

        #endregion
    }

}
