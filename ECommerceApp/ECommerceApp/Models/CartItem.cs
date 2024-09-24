using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("CartId")]
        [Required]
        public Cart Cart { get; set; } 

        [ForeignKey("ProductId")]
        [Required]
        public Product Product { get; set; }
    }
}
