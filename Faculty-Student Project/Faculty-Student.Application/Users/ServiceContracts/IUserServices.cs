using Faculty_Student.Application.Users.DTOs;
using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Application.Users.ServiceContracts;

public interface IUserServices
{
    Task<bool> RegisterUserAsync (InsertUserDto user);
}
