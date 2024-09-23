using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;
using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{
	public class ProductRepository(ECommerceDbContext context) : IProductRepository
	{
        public async Task<Product> GetProductByIdAsync(int id)
		{
			return await context.Products.FindAsync(id);
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await context.Products.ToListAsync();
		}

		public async Task AddProductAsync(Product product)
		{
			await context.Products.AddAsync(product);
			await context.SaveChangesAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			context.Products.Update(product); 
			await context.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int id)
		{
			var product = await context.Products.FindAsync(id);

			context.Products.Remove(product); 
			await context.SaveChangesAsync();
		}
	}
}
