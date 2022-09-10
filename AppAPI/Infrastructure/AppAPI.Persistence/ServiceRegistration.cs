using AppAPI.Application.Abstraction;
using AppAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Persistence
{
    public static class ServiceRegistration
    {
        //extension funtion
        //via this injection the app will pass/transact the specific services once its interface was called
        public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
