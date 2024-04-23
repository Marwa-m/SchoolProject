using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Bases;

namespace CleanArchitecture.Infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetAllStudentsAsync();

    }
}
