using AppAPI.Application.Abstractions.Storage;
using AppAPI.Application.Repositories;
using AppAPI.Application.RequestParameters;
using AppAPI.Application.ViewModels.Products;
using AppAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        readonly IFileWriteRepository _fileWriteRepository;
        readonly IFileReadRepository _fileReadRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        readonly IStorageService _storageService;


        public ProductsController(IProductReadRepository productReadRepository,
                                  IProductWriteRepository productWriteRepository,
                                  IWebHostEnvironment webHostEnvironment,
                                  IFileWriteRepository fileWriteRepository,
                                  IFileReadRepository fileReadRepository,
                                  IProductImageFileReadRepository productImageFileReadRepository,
                                  IProductImageFileWriteRepository productImageFileWriteRepository,
                                  IInvoiceFileReadRepository invoiceFileReadRepository,
                                  IInvoiceFileWriteRepository invoiceFileWriteRepository,
                                  IStorageService storageService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileWriteRepository = fileWriteRepository;
            _fileReadRepository = fileReadRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.CreateDate,
                p.UpdatedDate
            }).ToList();


            return Ok(new
            {
                totalCount,
                products
            });

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

        [HttpPost("[action]")]   //query string
        //action should be imported here because I already have a Http POST and so should be implemented here to the endpoint
        public async Task<IActionResult> Upload(string id)
        {


            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", Request.Form.Files);
            await _productImageFileWriteRepository.AddRangeAsync(result.Select(p => new ProductImageFile
            {
                FileName = p.fileName,
                Path = p.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());
            await _productImageFileWriteRepository.SaveAsync();


            return Ok();
        }


        [HttpGet("[action]/{id}")] //root data 
        public async Task<IActionResult> GetProductImages(string id)
        {
           Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles)
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

         
            return Ok(product.ProductImageFiles.Select(p => new
            {
                p.Path,
                p.FileName
            }));
          
        }
    }
}
