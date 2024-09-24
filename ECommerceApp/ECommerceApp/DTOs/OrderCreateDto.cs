namespace ECommerceApp.DTOs
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
