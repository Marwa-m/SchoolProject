using CleanArchitecture.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Service.Abstracts
{
    public interface IInstructroService
    {
        public Task<decimal> GetSalarySummationOfInstructor();

        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int Id);

        public Task<string> AddInstructorAsync(Instructor instructor, IFormFile file);
    }
}
