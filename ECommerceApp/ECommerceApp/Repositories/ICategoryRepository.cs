using System.Collections.Generic;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);

    }
}
