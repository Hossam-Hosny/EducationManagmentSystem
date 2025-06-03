using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class UserRepository
    (
                            IDbContext _db,
                            ILogger<UserRepository> _logger 
    )
    : IUserRepository
{
    public async Task<int> InsertUserAsync(USERS user)
    {
       using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation("open connection with database");

            var parameters = new DynamicParameters();
            parameters.Add("@Name",user.UserName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@PasswordHash", user.PasswordHash);
            parameters.Add("@Role", user.Role);


            return await connection.ExecuteAsync("sp_InsertUser",parameters,commandType:CommandType.StoredProcedure);

        }
    }
}
