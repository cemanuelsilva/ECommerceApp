using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = new Order();

        [ForeignKey("ProductId")]
        public required Product Product { get; set; }
    }
}
