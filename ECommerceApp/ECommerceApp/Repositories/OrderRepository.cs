using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;
using ECommerceApp.Models;
using System;

namespace ECommerceApp.Repositories
{
    public class OrderRepository(ECommerceDbContext context) : IOrderRepository
    {
        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await context.Orders
                .Include(c => c.User)
                .Include(c => c.OrderItems)
                .FirstOrDefaultAsync(c => c.OrderId == orderId);
        }

        public async Task<Order?> GetOrdersByUserIdAsync(int userId)
        {
            return await context.Orders
                .Include(c => c.User)
                .Include(c => c.OrderItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }


        public async Task RemoveOrderById(int orderId)
        {
            var order = await GetOrderByIdAsync(orderId);

            if (order != null)
            {
                context.Orders.Remove(order);
                await UpdateOrderAsync(order);
            }
        }
        public async Task UpdateOrderAsync(Order order)
        {
            context.Orders.Update(order);
            await context.SaveChangesAsync();
        }

    }
}
