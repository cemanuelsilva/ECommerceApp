using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetProductByIdAsync(int id);
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
	}
}