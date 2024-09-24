using ECommerceApp.Models;

namespace ECommerceApp.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<Order?> GetOrdersByUserIdAsync(int userId);
        Task AddOrderAsync(Order order);
        Task RemoveOrderById(int orderId);
        Task UpdateOrderAsync(Order order);
    }
}
