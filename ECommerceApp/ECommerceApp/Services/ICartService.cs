using ECommerceApp.Models;
using ECommerceApp.DTOs;

namespace ECommerceApp.Services
{
    public interface ICartService
    {
        Task<CartDto?> GetCartByIdAsync(int cartId);
        Task<CartDto?> GetCartByUserAsync(int userId);
        Task CreateCartForUserAsync(int userId);
        Task AddProductToCartAsync(int cartId, int productId);
        Task UpdateCartQuantityAsync(int cartId, int productId, int newQuantity);
        Task ClearCartAsync(int cartId);
        Task RemoveCartItemAsync(int cartId, int cartItemId);
    }

}
