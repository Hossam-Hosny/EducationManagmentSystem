using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class AssignmentRepository(IDbContext _db, ILogger<AssignmentRepository> _logger) : IAssignmentRepository
{
    public async Task<int> InsertAssignment(ASSIGNMENTS assignment)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation("Inserting Assignment into database ");

            var parameters = new DynamicParameters();
            parameters.Add("@TITLE",assignment.Title);
            parameters.Add("@DESCRIPTION", assignment.Description);
            parameters.Add("@DUEDATETIME", assignment.DueDateTime);
            parameters.Add("@FILEPATH", assignment.FilePath);
            parameters.Add("@CREATEDBYID", assignment.CreatedById);


            return await connection.ExecuteAsync("sp_InsertAssignment",parameters,commandType:CommandType.StoredProcedure);


        }

        
    }
}
