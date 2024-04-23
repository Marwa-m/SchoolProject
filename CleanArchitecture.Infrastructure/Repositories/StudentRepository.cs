using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields

        private readonly DbSet<Student> _students;
        #endregion

        #region Ctor
        public StudentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _students = dBContext.Set<Student>();
        }
        #endregion

        #region Handles function
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _students.Include(x => x.Department).ToListAsync();
        }

        #endregion
    }

}
