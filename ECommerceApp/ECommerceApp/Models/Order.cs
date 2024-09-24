using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}
