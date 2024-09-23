using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task AddProductAsync(ProductDto productDto);
        Task UpdateProductAsync(ProductDto productDto);
        Task DeleteProductAsync(int id);
    }

}