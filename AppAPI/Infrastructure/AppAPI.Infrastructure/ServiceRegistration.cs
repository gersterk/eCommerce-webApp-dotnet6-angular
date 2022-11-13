using AppAPI.Application.Abstractions;
using AppAPI.Application.Abstractions.Storage;
using AppAPI.Infrastructure.Enums;
using AppAPI.Infrastructure.Services;
using AppAPI.Infrastructure.Services.Storage;
using AppAPI.Infrastructure.Services.Storage.Azure;
using AppAPI.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();

        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage   
        {
            serviceCollection.AddScoped<IStorage, T>();

        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.AWS:
                    break;

                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();

                    break;
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();

                    break;
            }

        }

    }
}
