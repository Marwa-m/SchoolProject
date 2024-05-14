using CleanArchitecture.Service.Abstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Service.Implementation
{
    public class FileService : IFileService
    {
        #region Fields
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion

        #region CTOR
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Functions
        public async Task<string> UploadImage(string location, IFormFile file)
        {
            var path = _webHostEnvironment.WebRootPath + "/" + location + "/";
            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    var extension = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extension;
                    using (FileStream fileStream = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return $"{path}{fileName}";
                    }
                }
                catch (Exception ex)
                {
                    return "FailedToUpload";
                }
            }
            else
            {
                return "NoImage";
            }
        }
        #endregion

    }
}
