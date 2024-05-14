using CleanArchitecture.Data.Entities;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Abstracts.Functions;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Service.Implementation
{
    public class InstrucotrService : IInstructroService
    {
        #region Fields
        private readonly ApplicationDBContext _dBContext;
        private readonly IInstructorFunctionRepository _functionRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region CTOR
        public InstrucotrService(ApplicationDBContext dBContext,
            IInstructorFunctionRepository functionRepository,
            IInstructorRepository instructorRepository,
            IFileService fileService,
            IHttpContextAccessor httpContextAccessor)
        {
            _dBContext = dBContext;
            _functionRepository = functionRepository;
            _instructorRepository = instructorRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{context.Scheme}:// {context.Host}";
            var imageUrl = await _fileService.UploadImage("Instructors", file);
            switch (imageUrl)
            {
                case "FailedToUpload": return "FailedToUpload";
                case "NoImage": return "NoImage";
            }
            instructor.Image = baseUrl + imageUrl;
            try
            {
                var result = await _instructorRepository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception ex)
            {
                return "FailedToAdd";
            }


        }
        #endregion
        #region Function
        public Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            using (var cmd = _dBContext.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                result = _functionRepository.GetSalarySummationOfInstructor("SELECT dbo.GetSalarySummation()", cmd);
            }
            return Task.FromResult(result);
        }

        public async Task<bool> IsNameExist(string name)
        {
            var isExist = _instructorRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(name)).FirstOrDefault();
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int Id)
        {
            var isExist = await _instructorRepository.GetTableNoTracking().Where(x => (x.NameAr.Equals(name) || x.NameEn.Equals(name)) & !x.DID.Equals(Id)).FirstOrDefaultAsync();
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        #endregion

    }
}
