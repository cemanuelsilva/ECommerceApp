using ECommerceApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = [];
    }
}

