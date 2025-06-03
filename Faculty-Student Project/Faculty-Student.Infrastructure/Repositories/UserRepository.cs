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
    public async Task<int> DeleteUserAsync(int userId)
    {

        using(var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Deleting User of Id = {userId}");

            return await connection.ExecuteAsync("sp_DeleteUser", new { USERID =  userId } , 
                commandType: CommandType.StoredProcedure);


        }


    }

    public async Task<USERS?> GetUserByEmailAsync(string email)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting User of {email} from database");

            return await connection.QueryFirstOrDefaultAsync<USERS>("sp_GetUserByEmail",
                new { EMAIL = email },
                commandType: CommandType.StoredProcedure);



        }
    }

    public async Task<USERS?> GetUserByIdAsync(int userId)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting User of {userId} from database");

            return await connection.QueryFirstOrDefaultAsync<USERS>("sp_GetUserById",
                new { USERID = userId },
                commandType:CommandType.StoredProcedure);
            


        }
    }

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

    public async Task<int> UpdateUserAsync(USERS user)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Updating User in  database");

            var parameters = new DynamicParameters();
            parameters.Add("@USERID",user.UserId);
            parameters.Add("@NAME", user.UserName);
            parameters.Add("@EMAIL", user.Email);
            parameters.Add("@PASSWORD", user.PasswordHash);
            parameters.Add("@ROLE", user.Role);

            return await connection.ExecuteAsync("sp_UpdateUser" , parameters , commandType:CommandType.StoredProcedure);



        }
    }
}
