using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task UpdateCategoryAsync(CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);

    }
}
