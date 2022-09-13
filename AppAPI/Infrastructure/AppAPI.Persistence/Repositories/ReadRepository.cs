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

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetSingleAsynch(Expression<Func<T, bool>> method) 
            =>await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) 
            => Table.Where(method);

        public async Task<T> GetByIdAsynch(string id) //marker pattern
            => await Table.FirstOrDefaultAsync(value => value.Id==Guid.Parse(id)); 

        //id base reflection issue/topic, worth to learn but marker pattern is better 
    }
}
