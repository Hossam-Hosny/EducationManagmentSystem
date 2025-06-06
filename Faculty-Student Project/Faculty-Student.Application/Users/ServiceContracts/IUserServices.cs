using Faculty_Student.Application.Users.DTOs;
using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Application.Users.ServiceContracts;

public interface IUserServices
{
    Task<bool> RegisterUserAsync (InsertUserDto user);
    Task<UserDto?> ValidateUserAsync(string email,string password);
    Task <UserDto?> GetUserByIdAsync (int userId);
    Task<bool> UpdateUserAsync(UpdateUserDto dto);
    Task<bool> DeleteUserAsync(int userId);
}
