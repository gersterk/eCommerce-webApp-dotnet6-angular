using AppAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(), Name="Product 1", Price=150, CreateDate= DateTime.UtcNow, Stock=35},
                new(){Id=Guid.NewGuid(), Name="Product 2", Price=2, CreateDate= DateTime.UtcNow, Stock=1},
                new(){Id=Guid.NewGuid(), Name="Product 3", Price=87, CreateDate= DateTime.UtcNow, Stock=17},
                new(){Id=Guid.NewGuid(), Name="Product 4", Price=23, CreateDate= DateTime.UtcNow, Stock=19}

            });
            var counts = await _productWriteRepository.SaveAsync();
        }
    }
}
