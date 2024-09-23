using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Services;
using ECommerceApp.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _productService.UpdateProductAsync(productDto);
            //return NoContent();
            return Ok(productDto);
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound("Product Not Found");
            }

            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
