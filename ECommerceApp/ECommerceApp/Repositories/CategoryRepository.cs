using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;
using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{
    public class CategoryRepository(ECommerceDbContext context) : ICategoryRepository
    {
        public async Task<Category> GetCategoryByIdAsync(int id)
        {   
            return await context.Categories.FindAsync(id);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();

        }

        public async Task UpdateCategoryAsync(Category category)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);

            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

    }
    
}
