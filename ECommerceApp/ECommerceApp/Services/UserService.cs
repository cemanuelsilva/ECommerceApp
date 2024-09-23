using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ECommerceApp.DTOs;
using ECommerceApp.Models;
using ECommerceApp.Repositories;


namespace ECommerceApp.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly PasswordHasher<User> _passwordHasher = new();

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);

            if (user == null) { throw new Exception("User not found"); }

            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var existingUser = await userRepository.GetUserByIdAsync(userDto.UserId);
            if (existingUser != null)
            {
                throw new Exception("User ID already exists.");
            }

            var existingUserByUsername = await userRepository.GetUserByNameAsync(userDto.UserName);
            if (existingUserByUsername != null)
            {
                throw new Exception("Username already exists.");
            }

            var existingUserByEmail = await userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUserByEmail != null)
            {
                throw new Exception("Email already exists.");
            }


            var userCreated = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
            };

            //Hash the password
            userCreated.PasswordHash = _passwordHasher.HashPassword(userCreated, userDto.PasswordHash);

            await userRepository.AddUserAsync(userCreated);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
           
            var existingUser = await userRepository.GetUserByIdAsync(userDto.UserId);

            if (existingUser == null)
            {
                throw new Exception("User not found.");
            }

         
            existingUser.UserName = userDto.UserName;
            existingUser.Email = userDto.Email;

           
            if (!string.IsNullOrEmpty(userDto.PasswordHash))
            {
                existingUser.PasswordHash = userDto.PasswordHash;
            }

            await userRepository.UpdateUserAsync(existingUser);
        }

        public bool VerifyPassword(User user, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await userRepository.GetUserByIdAsync(id);
            
            if(existingUser == null) { throw new Exception("User not found"); }
            
            await userRepository.DeleteUserAsync(id);
        }

        
    }
}
