using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Helper;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();

        public Task<Student> GetStudentByIdWithIncludeAsync(int id);
        public Task<Student> GetStudentByIdAsync(int id);
        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderEnum orderEnum, string? search);

        public IQueryable<Student> GetStudentsQueryable();
        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int Id);
        public Task<string> AddAsync(Student student);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);

        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int Id);
    }
}
