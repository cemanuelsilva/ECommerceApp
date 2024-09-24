using ECommerceApp.Models;
using ECommerceApp.Repositories;
using ECommerceApp.DTOs;

namespace ECommerceApp.Services
{
    public interface IOrderService
    {
        //IQueryable<OrderDto> GetAllOrders();
        Task<OrderDto> GetOrderById(int id);
        Task<OrderDto> GetOrdersByUserId(int UserId);
        Task AddOrder(int userId);
        //Task RemoveOrderById(int orderId);
    }
}
