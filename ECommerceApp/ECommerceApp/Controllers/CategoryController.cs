using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Services;
using ECommerceApp.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /*
        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var Categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(Categories);
        }
        */
        // GET: api/Category/{id}

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            
            if (category == null)
            {
                return NotFound();
            
            }
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult> CreateCategory(CategoryDto CategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.AddCategoryAsync(CategoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = CategoryDto.Id }, CategoryDto);
        }

        // PUT: api/Category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto CategoryDto)
        {
            if (id != CategoryDto.Id)
            {
                return BadRequest("Category ID mismatch");
            }

            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _categoryService.UpdateCategoryAsync(CategoryDto);
            //return NoContent();
            return Ok(CategoryDto);
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound("Category Not Found");
            }

            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
