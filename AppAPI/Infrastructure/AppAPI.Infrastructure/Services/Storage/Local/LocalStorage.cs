using AppAPI.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

        }

        public Task DeleteAsync(string path, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string path)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string path, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();


            foreach (IFormFile file in files)
            {

                bool result = await CopyFileAsync($"{path}\\{fileNewName}", file);
                //string interpolation, I could have use path.combine too. but I need to practice this :)
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
                results.Add(result);
            }


            if (results.TrueForAll(r => r.Equals(true)))
            {
                return datas;

            }
            return null;
        }
    }
}
