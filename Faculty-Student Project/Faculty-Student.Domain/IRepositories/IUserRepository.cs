using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IUserRepository
{

    Task<int> InsertUserAsync(USERS user);
    Task<USERS?> GetUserByIdAsync(int userId);
    Task<USERS?> GetUserByEmailAsync (string email);
    Task<int> UpdateUserAsync(USERS user);
    Task<int> DeleteUserAsync(int userId);


}
