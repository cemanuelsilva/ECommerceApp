using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Data;
using ECommerceApp.Models;
using ECommerceApp.DTOs;

namespace ECommerceApp.Repositories
{
    public class UserRepository(ECommerceDbContext context) : IUserRepository
    {
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);

        }

        public async Task<User?> GetUserByNameAsync(string name)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName == name);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }


        public async Task UpdateUserAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var users = await context.Users.FindAsync(id);

            context.Users.Remove(users);
            await context.SaveChangesAsync();
        }

        
    }
}
