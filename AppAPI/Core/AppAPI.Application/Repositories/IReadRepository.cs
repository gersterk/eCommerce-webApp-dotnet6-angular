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
        IQueryable<T> GetAll(bool tracking = true); //if wje would be looking for something to the with memory, we would use IENumerable but nah, lets query
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking=true );

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //brings THE ONE
        Task<T> GetByIdAsync(string id, bool tracking = true); //brings the choosen one
        
        //tacking bool is for EF tracking 
    }
}
