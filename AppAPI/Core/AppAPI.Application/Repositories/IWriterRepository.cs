
using AppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Application.Repositories
{
    public interface IWriterRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model); //well why bool, dunno, I feel so, it should true or false, is it added?
        Task<bool> AddAsync(List<T> model);
        Task<bool> Remove(T model);
        Task<bool> Remove(string id);

        Task<bool> UpdateAsynch(T model);
    }
}
