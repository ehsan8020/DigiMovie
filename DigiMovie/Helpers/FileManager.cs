using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Helpers
{
    public class FileManager : IFileManager
    {
        private readonly IHostingEnvironment _env;
        public FileManager( IHostingEnvironment env)
        {
            _env = env;
        }

        public void DeleteFile(string path)
        {
            var absolutePath = _env.WebRootPath + path;
            if (File.Exists(absolutePath))
                File.Delete(absolutePath);
        }

        public void SaveFile(IFormFile file, string path)
        {
            var absolutePath = Path.Combine(_env.WebRootPath, path);

            using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
