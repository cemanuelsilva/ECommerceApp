using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{

    public class ProductService(IProductRepository repository, ICategoryRepository categoryRepository) : IProductService
    {
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await repository.GetProductByIdAsync(id);
            if (product == null) { throw new Exception("Product not found"); }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await repository.GetAllProductsAsync();
            if(products == null) { throw new Exception("Products not found"); }

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId
            });
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            
            var existingProduct = await repository.GetProductByIdAsync(productDto.Id);
            if (existingProduct != null)
            {
                throw new Exception("Product with this ID already exists.");
            }

            var existingCategory = await categoryRepository.GetCategoryByIdAsync(productDto.CategoryId);
            if (existingCategory == null)
            {
                throw new Exception("Category not found.");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CategoryId = productDto.CategoryId,  
                //Category = existingCategory          // Optional
            };

            await repository.AddProductAsync(product);
        }


        public async Task UpdateProductAsync(ProductDto productDto)
        {
            
            
            var existingProduct = await repository.GetProductByIdAsync(productDto.Id);
            var existingCategory = await categoryRepository.GetCategoryByIdAsync(productDto.Id);

            if (existingProduct == null) { throw new Exception("Product not found."); }
            if (existingCategory == null) { throw new Exception("Category not found."); }
            
            existingProduct.Id = productDto.Id;
            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.Stock = productDto.Stock;
            existingProduct.CategoryId = productDto.CategoryId;

            await repository.UpdateProductAsync(existingProduct);
        }

        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await repository.GetProductByIdAsync(id);
            if (existingProduct == null) { throw new Exception("Product not found."); }
            
            await repository.DeleteProductAsync(id);
        }
    }
}
