using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;


namespace ECommerceApp.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);

            if(category == null) { throw new Exception("Category not found"); }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var existingCategory = await categoryRepository.GetCategoryByIdAsync(categoryDto.Id);

            if(existingCategory != null) { throw new Exception("Category already exists"); }

            var newCategory = new Category { Id = categoryDto.Id, Name = categoryDto.Name };

            await categoryRepository.AddCategoryAsync(newCategory);
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var existingCategory = await categoryRepository.GetCategoryByIdAsync(categoryDto.Id);
            
            if(existingCategory == null) { throw new Exception("Category doesn't exists"); }

            existingCategory.Name = categoryDto.Name;

            await categoryRepository.UpdateCategoryAsync(existingCategory);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
