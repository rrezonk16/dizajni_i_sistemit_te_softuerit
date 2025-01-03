using dizajni_i_sistemit_softuerik.Entities;
using dizajni_i_sistemit_softuerik.Repositories;
using dizajni_i_sistemit_softuerik.DTOs;

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dizajni_i_sistemit_softuerik.Dtos;

namespace dizajni_i_sistemit_softuerik.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher; // Adjusted to use User type
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;

        public UserService(IUserRepository userRepository,
                           IPasswordHasher<User> passwordHasher,
                           IRoleRepository roleRepository,
                           IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
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
                RoleId = 3 // You can modify the role assignment logic here
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
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user;
        }

        // New method to get the user's role and permissions
        public async Task<RolePermissionsDto> GetUserRoleAndPermissionsAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var role = await _roleRepository.GetRoleByUserIdAsync(user.RoleId);
            if (role == null)
                throw new Exception("Role not found for user");

            var permissions = await _permissionRepository.GetByRoleIdAsync(role.Id);

            // Return role and permissions in DTO
            var rolePermissionsDto = new RolePermissionsDto
            {
                RoleName = role.Name,
                Permissions = new List<string>()
            };

            foreach (var permission in permissions)
            {
                rolePermissionsDto.Permissions.Add(permission.PermissionName);
            }

            return rolePermissionsDto;
        }
    }
}
