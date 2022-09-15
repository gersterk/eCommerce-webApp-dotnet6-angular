 using AppAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.Application.Repositories;
using AppAPI.Persistence.Repositories;

namespace AppAPI.Persistence
{
    public static class ServiceRegistration
    {

        //extension funtion => IoC 
        //via this injection the app will pass/transact the specific services once its interface was called
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
           
            //Dependency Injections
           
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();  //AddScope was disposing context object. Because scope disposes each object that have created due to a request
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            

        }
    }
}