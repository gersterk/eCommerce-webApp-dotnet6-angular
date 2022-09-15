using AppAPI.Application.Repositories;
using AppAPI.Domain.Entities.Common;
using AppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ECommerceAPIDbContext _context;

        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();
            return query;
            
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = Table.AsTracking();
            return await query.FirstOrDefaultAsync(method);


        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            if (!tracking)
                query = query.AsNoTracking();
            return query;

        }


        public async Task<T> GetByIdAsync(string id, bool tracking = true) //marker pattern

        /*await Table.FirstOrDefaultAsync(value => value.Id == Guid.Parse(id));*/
        //=> await Table.FindAsync(Guid.Parse(id));

        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
                //IQueryable doesnot support FindAsync and so we have go through marker pattern to get the ID
        }
        //id base reflection issue/topic, worth to learn but marker pattern is better 
    }
}
