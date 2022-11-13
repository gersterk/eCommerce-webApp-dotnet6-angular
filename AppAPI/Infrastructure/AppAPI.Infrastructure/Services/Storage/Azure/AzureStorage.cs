using AppAPI.Application.Abstractions.Storage.Azure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Infrastructure.Services.Storage.Azure
{
    public class AzureStorage : IAzureStorage
    {
        public Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            throw new NotImplementedException();
        }
    }
}
