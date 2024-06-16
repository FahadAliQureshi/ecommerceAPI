// IUserService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApi.Models;

namespace ECommerceApi.Services
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}

// UserService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApi.Models;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            // Additional logic for user creation (e.g., password hashing, validation)
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            // Additional logic for user update
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            // Additional logic for user deletion
            await _userRepository.DeleteAsync(id);
        }
    }
}
