using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.Models;
using ECommerceApp.DTOs;
using ECommerceApp.Repositories;

namespace ECommerceApp.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByNameAsync(string name);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
