using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{
    public class CartService(ICartRepository cartRepository, IProductService productService, ICategoryService categoryService) : ICartService
    {
        public async Task<CartDto?> GetCartByIdAsync(int cartId)
        {
            var cart = await cartRepository.GetCartByIdAsync(cartId);
            if (cart == null) { throw new Exception("Cart Not Found"); }

            return MapToDto(cart);
        }

        public async Task<CartDto?> GetCartByUserAsync(int userId)
        {
            var cart = await cartRepository.GetCartByUserAsync(userId);
            if (cart == null) { throw new Exception("User Cart Not Found"); }

            return MapToDto(cart);
        }

        public async Task CreateCartForUserAsync(int userId)
        {
            var cart = new Cart { UserId = userId };
            await cartRepository.AddCartAsync(cart);
        }

        public async Task AddProductToCartAsync(int cartId, int productId)
        {
            // Fetch the cart directly from the repository
            var cart = await cartRepository.GetCartByIdAsync(cartId);
            if (cart == null)
                throw new Exception("Cart not found.");

            // Fetch product details
            var product = await productService.GetProductByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found.");

            // Validate category
            var category = await categoryService.GetCategoryByIdAsync(product.CategoryId);
            if (category == null)
                throw new Exception("Category not found.");

            // Ensure cart items are initialized
            if (cart.CartItems == null)
                cart.CartItems = new List<CartItem>();

            // Add or update product in cart
            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = 1 });
            }

            // Save changes directly
            await cartRepository.UpdateCartAsync(cart);
        }


        public async Task UpdateCartQuantityAsync(int cartId, int productId, int newQuantity)
        {
           
            var cart = await cartRepository.GetCartByIdAsync(cartId);
            if (cart == null)
            {
                throw new Exception("Cart not found.");
            }

            
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity = newQuantity; // Update quantity
            }
            else
            {
                throw new Exception("Cart item not found.");
            }

            // Update the cart in the repository
            await cartRepository.UpdateCartAsync(cart);
        }




        public async Task ClearCartAsync(int cartId)
        {
            var cart = await GetCartByIdAsync(cartId);
            if(cart == null) { throw new Exception("Cart Not Found"); }

            await cartRepository.ClearCartAsync(cartId);
        }

        public async Task RemoveCartItemAsync(int cartId, int cartItemId)
        {
            var cart = await GetCartByIdAsync(cartId);
            if (cart == null) { throw new Exception("Cart Not Found"); }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
            if(cartItem == null) { throw new Exception("Product Not Found"); }

            await cartRepository.RemoveCartItemAsync(cartId, cartItemId);
        }

        private static CartDto MapToDto(Cart? cart)
        {
            if (cart == null) return null;

            return new CartDto
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                CartItems = cart.CartItems.Select(ci => new CartItemDto
                {
                    CartItemId = ci.CartItemId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }

        
    }
}
