using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productService.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine(item.Category);
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            try
            {
                var product = await _productService.GetById(id);

                if (product == null)
                {
                    return NotFound("There is no product with id:" + id);
                }

                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(int categoryId)
        {
            var products = await _productService.GetByCategory(categoryId);
            if (products == null)
            {
                return NotFound("There are no products matching this category id:" + categoryId);
            }
            return Ok(products);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Product productModel)
        {
            var category = await _productService.GetById(id);
            if (category != null)
            {
                await _productService.Update(productModel);
                return Ok();
            }

            return NotFound();
        }
    }
}