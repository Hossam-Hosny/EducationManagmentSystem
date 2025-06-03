using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IUserRepository
{

    Task<int> InsertUserAsync(USERS user);

}
