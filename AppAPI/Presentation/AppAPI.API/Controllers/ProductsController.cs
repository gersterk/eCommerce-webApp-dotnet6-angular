﻿using AppAPI.Application.Repositories;
using AppAPI.Application.RequestParameters;
using AppAPI.Application.Services;
using AppAPI.Application.ViewModels.Products;
using AppAPI.Domain.Entities;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IFileService _fileService;
        readonly IFileWriteRepository _fileWriteRepository;
        readonly IFileReadRepository _fileReadRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;



        public ProductsController(
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            IFileService fileService,
            IWebHostEnvironment webHostEnvironment)

        {
            _fileService = fileService;
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;


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

        [HttpPost("[action]")] 
        //action should be imported here because I already have a Http POST and so should be implemented here to the endpoint
        public async Task<IActionResult> Upload()
        {

            _fileService.UploadAsync("resource/product-images", Request.Form.Files);

            return Ok();
        }

    }
}
