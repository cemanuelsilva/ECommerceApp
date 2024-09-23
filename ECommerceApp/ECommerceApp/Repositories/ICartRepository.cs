using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByIdAsync(int cartId);
        Task<Cart?> GetCartByUserAsync(int userId);
        Task AddCartAsync(Cart cart);
        Task UpdateCartAsync(Cart cart);
        Task ClearCartAsync(int cartId);
        Task RemoveCartItemAsync(int cartId, int cartItemId);

    }
}
