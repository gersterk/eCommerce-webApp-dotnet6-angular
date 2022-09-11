 using AppAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Persistence
{
    public static class ServiceRegistration
    {

        //extension funtion => IoC 
        //via this injection the app will pass/transact the specific services once its interface was called
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql
            ("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=ECommerceAPIDb;")); 
        }
    }
}
