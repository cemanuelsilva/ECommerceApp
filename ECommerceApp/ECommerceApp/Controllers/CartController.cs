using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartByUser(int userId)
        {
            var cart = await cartService.GetCartByUserAsync(userId);
            return cart != null ? Ok(cart) : NotFound("Cart not found.");
        }

        [HttpPost("{userId}/create")]
        public async Task<IActionResult> CreateCart(int userId)
        {
            await cartService.CreateCartForUserAsync(userId);
            return Ok("Cart created.");
        }

        [HttpPost("{cartId}/add-product/{productId}")]
        public async Task<IActionResult> AddProductToCart(int cartId, int productId)
        {
            await cartService.AddProductToCartAsync(cartId, productId);
            return Ok("Product added to cart.");
        }

        [HttpPut("{cartId}/update-quantity/{productId}")]
        public async Task<IActionResult> UpdateCartQuantity(int cartId, int productId, [FromBody] int newQuantity)
        {
            await cartService.UpdateCartQuantityAsync(cartId, productId, newQuantity);
            return Ok("Quantity updated.");
        }

        [HttpDelete("{cartId}/clear")]
        public async Task<IActionResult> ClearCart(int cartId)
        {
            await cartService.ClearCartAsync(cartId);
            return Ok("Cart cleared.");
        }

        [HttpDelete("{cartId}/remove-item/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartId, int cartItemId)
        {
            await cartService.RemoveCartItemAsync(cartId, cartItemId);
            return Ok("Cart item removed.");
        }
    }

}




