using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<Cart> Carts { get; set; } = [];
    }
}
