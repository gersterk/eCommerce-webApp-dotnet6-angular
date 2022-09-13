using AppAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(); //if we would be looking for something to the with memory, we would use IENumerable but nah, lets query
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);

        Task<T> GetSingleAsynch(Expression<Func<T, bool>> method); //brings THE ONE
        Task<T> GetByIdAsynch(string id); //brings the choosen one
        
    }
}
