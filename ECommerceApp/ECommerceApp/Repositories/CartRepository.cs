using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;
using ECommerceApp.Models;
using System;

namespace ECommerceApp.Repositories
{
    public class CartRepository(ECommerceDbContext context) : ICartRepository
    {
        public async Task<Cart?> GetCartByIdAsync(int cartId)
        {
            return await context.Carts
                .Include(c => c.User) 
                .Include(c => c.CartItems) 
                .FirstOrDefaultAsync(c => c.CartId == cartId);
        }

        public async Task<Cart?> GetCartByUserAsync(int userId)
        {
            return await context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddCartAsync(Cart cart)
        {
            await context.Carts.AddAsync(cart);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            context.Carts.Update(cart);
            await context.SaveChangesAsync();
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cart = await GetCartByIdAsync(cartId);
            if (cart != null)
            {
                cart.CartItems.Clear();
                await UpdateCartAsync(cart);
            }
        }

        public async Task RemoveCartItemAsync(int cartId, int cartItemId)
        {
            var cart = await GetCartByIdAsync(cartId);
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
                if (cartItem != null)
                {
                    cart.CartItems.Remove(cartItem);
                    await UpdateCartAsync(cart);
                }
            }
        }

    }
}
