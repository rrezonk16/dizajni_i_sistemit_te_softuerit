﻿using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace dizajni_i_sistemit_softuerik.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher; // Adjusted to use User type

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> RegisterAsync(string name, string surname, string email, string password, string phoneNumber, string address)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(email);
            if (existingUser != null)
                throw new Exception("User already exists");

            var passwordHash = _passwordHasher.HashPassword(new User { Email = email }, password);
            var user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                PasswordHash = passwordHash,
                PhoneNumber = phoneNumber,
                Address = address,
                RoleId = 3
            };

            return await _userRepository.RegisterUserAsync(user);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || _passwordHasher.VerifyHashedPassword(new User { Email = email }, user.PasswordHash, password) != PasswordVerificationResult.Success)
                throw new Exception("Invalid login credentials");

            return user;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }
    }
}
