using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Helper;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Service.Implementation
{

    public class StudentService : IStudentService
    {
        #region Field
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Ctor

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Method
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                                .Include(x => x.Department)
                                                .Where(x => x.StudentID.Equals(id))
                                                .FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return "Success";
        }
        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
            }
            catch (Exception)
            {

                await trans.RollbackAsync();
                return "Failed";
            }


            return "Success";
        }
        public async Task<bool> IsNameExist(string name)
        {
            var studentExist = _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(name)).FirstOrDefault();
            if (studentExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int Id)
        {
            var studentExist = await _studentRepository.GetTableNoTracking().Where(x => (x.NameAr.Equals(name) || x.NameEn.Equals(name)) & !x.StudentID.Equals(Id)).FirstOrDefaultAsync();
            if (studentExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                                .Where(x => x.StudentID.Equals(id))
                                                .FirstOrDefault();
            return student;
        }

        public IQueryable<Student> GetStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }
        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int Id)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(Id)).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQueryable(StudentOrderEnum orderEnum, string? search)
        {
            var query = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null) query = query.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));
            switch (orderEnum)
            {
                case StudentOrderEnum.StudentID:
                    query = query.OrderBy(x => x.StudentID);
                    break;
                case StudentOrderEnum.Name:
                    query = query.OrderBy(x => x.NameAr);
                    break;
                case StudentOrderEnum.Address:
                    query = query.OrderBy(x => x.Address);
                    break;
                case StudentOrderEnum.Department:
                    query = query.OrderBy(x => x.Department);
                    break;
            }
            return query;
        }

        #endregion
    }
}
