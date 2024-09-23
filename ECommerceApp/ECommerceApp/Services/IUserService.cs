using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
