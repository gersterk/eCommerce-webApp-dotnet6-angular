using AppAPI.Application.Abstraction;
using AppAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new()    //=>target type helps to shorten codes to write, returns authomatically the type we pass ...List<>

        {
            new(){Id=Guid.NewGuid(),Name= "Product 1", Price = 50 },
            new(){Id=Guid.NewGuid(),Name= "Product 2", Price = 50 },
            new(){Id=Guid.NewGuid(),Name= "Product 3", Price = 50 }
        };
    }
}
