namespace ECommerceApp.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public required string UserName { get; set; } 
        public required string Email { get; set; } 
        public string PasswordHash { get; set; } = string.Empty.ToString();
        

    }
}
