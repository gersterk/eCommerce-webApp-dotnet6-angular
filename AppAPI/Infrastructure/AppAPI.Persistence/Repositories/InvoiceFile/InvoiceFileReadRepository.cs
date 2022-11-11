using AppAPI.Application.Repositories;
using AppAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AppAPI.Domain.Entities;

namespace AppAPI.Persistence.Repositories
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }

        DbSet<Domain.Entities.InvoiceFile> IRepository<Domain.Entities.InvoiceFile>.Table => throw new NotImplementedException();

        public Task<Domain.Entities.InvoiceFile> GetSingleAsync(Expression<Func<Domain.Entities.InvoiceFile, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Entities.InvoiceFile> GetWhere(Expression<Func<Domain.Entities.InvoiceFile, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        IQueryable<Domain.Entities.InvoiceFile> IReadRepository<Domain.Entities.InvoiceFile>.GetAll(bool tracking)
        {
            throw new NotImplementedException();
        }

        Task<Domain.Entities.InvoiceFile> IReadRepository<Domain.Entities.InvoiceFile>.GetByIdAsync(string id, bool tracking)
        {
            throw new NotImplementedException();
        }
    }
}
