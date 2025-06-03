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

:IUserServices
{
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
