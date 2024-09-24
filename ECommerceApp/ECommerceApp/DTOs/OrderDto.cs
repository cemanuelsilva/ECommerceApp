using ECommerceApp.Models;

namespace ECommerceApp.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
