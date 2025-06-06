using Faculty_Student.Application.Users.DTOs;
using Faculty_Student.Application.Users.ServiceContracts;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace Faculty_Student.Application.Users.Services;

internal class UserServices
(
                 IUserRepository _userRepository,
                 ILogger<UserServices> _logger
)

: IUserServices
{
    public async Task<bool> DeleteUserAsync(int userId)
    {
        return await _userRepository.DeleteUserAsync(userId) > 0;
    }

    public async Task<UserDto?> GetUserByIdAsync(int userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        if (user is null) return null;

        return new UserDto
        {
            UserId = user.UserId,
            Name = user.UserName,
            Email = user.Email,
            Role = user.Role
        };
    }

    public async Task<bool> RegisterUserAsync(InsertUserDto user)
    {

        string PasswordHash = HashPassword(user.Password);

        var USER = new USERS
        {
            UserName = user.Name,
            Email = user.Email,
            PasswordHash = PasswordHash,
            Role = Convert.ToString(user.Role)

        };
        int result = await _userRepository.InsertUserAsync(USER);
        return result > 0;



    }

    public async Task<bool> UpdateUserAsync(UpdateUserDto dto)
    {
        var user = new USERS
        {
            UserName = dto.Name,
            Email = dto.Email,

            Role = dto.Role    
        };
        return await _userRepository.UpdateUserAsync(user) > 0;

    }

    public async Task<UserDto?> ValidateUserAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is null) return null;

        string passwordHash = HashPassword(password);
        if (user.PasswordHash != passwordHash) return null;

        return new UserDto
        {
            UserId = user.UserId,
            Name = user.UserName,
            Email = user.Email,
            Role = user.Role
        };
    }

    private string HashPassword(string Password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(Password);
            var hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
