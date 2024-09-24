using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{
    public class OrderService(IProductRepository productRepository, IOrderRepository orderRepository,ICartService cartService, IUserService userService) : IOrderService
    {

        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await orderRepository.GetOrderByIdAsync(id);

            if (order == null)
                throw new Exception("Order Not Found");

            return MapToDto(order);
        }

        public async Task<OrderDto> GetOrdersByUserId(int userId)
        {
            var orders = await orderRepository.GetOrdersByUserIdAsync(userId);

            if (orders == null)
                throw new Exception("User Order Not Found");

            return MapToDto(orders);
        }

        public async Task AddOrder(int userId)
        {
            // 1. Fetch the cart for the user
            var cart = await cartService.GetCartByUserAsync(userId);
            if (cart == null || !cart.CartItems.Any())
            {
                throw new Exception("No items in the cart to place an order.");
            }

            // 2. Create a new order based on the cart's items
            var orderItems = new List<OrderItem>();

            foreach (var cartItem in cart.CartItems)
            {
                // Fetch the product from the ProductService to attach to the order item
                var product = await productRepository.GetProductByIdAsync(cartItem.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with ID {cartItem.ProductId} not found.");
                }

                orderItems.Add(new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Product = product,   // Assign the actual product entity
                    Quantity = cartItem.Quantity
                });
            }

            var order = new Order
            {
                UserId = userId,
                OrderItems = orderItems,
                OrderDate = DateTime.Now
            };

            // 3. Save the order to the database
            await orderRepository.AddOrderAsync(order);

            // 4. Clear the cart for the user
            await cartService.ClearCartAsync(cart.CartId);
        }



        private static OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    OrderItemId = oi.OrderItemId,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList(),
            };
        }


    }
}
