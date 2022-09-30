using AppAPI.Application.Repositories;
using AppAPI.Application.RequestParameters;
using AppAPI.Application.ViewModels.Products;
using AppAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppAPI.API.Controllers
{

    //Test controller so far

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;


        public ProductsController(
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository)

        {

            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            var products = _productReadRepository.GetAll().Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.CreateDate,
                p.UpdatedDate
            }).Take(pagination.Page * pagination.Size).Skip(pagination.Size);


            return Ok(products);

        }
        [HttpGet("{id}")]
        //Paramethic GET 
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false)); //tracking is false cuz we do not CRUD yet, for performance sake
            
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model) //post attributes shouldnt be applying any post proccess by The Entity : like (Product model) 
        {
            
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock
            });

            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id, false);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;

            await _productWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            
            return Ok();
        }

    }
}
