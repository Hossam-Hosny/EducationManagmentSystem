using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class AssignmentRepository(IDbContext _db, ILogger<AssignmentRepository> _logger) : IAssignmentRepository
{
    public async Task<int> DeleteAssignmentAsync(int assignmentId)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Deleting Assignment of Id = {assignmentId}");

            return await connection.ExecuteAsync("sp_DeleteAssignment", new { ASSIGNMENTID = assignmentId },
                commandType: CommandType.StoredProcedure);


        }

    }

    public async Task<List<ASSIGNMENTS>?> GetAssignmentByFacultyIdAsync(int facultyId)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Assignments of Faculty id  {facultyId} from database");

            var result =  await connection.QueryAsync<ASSIGNMENTS>("sp_GetAssignmentsByFaculty",
                new { FACULTYID = facultyId },
                commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
    }

    public async Task<ASSIGNMENTS?> GetAssignmentByIdAsync(int assignmentId)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Assignment of {assignmentId} from database");

            return await connection.QueryFirstOrDefaultAsync<ASSIGNMENTS>("sp_GetAssignmentById",
                new { ASSIGNMENTID = assignmentId },
                commandType: CommandType.StoredProcedure);



        }
    }

   

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

    public async Task<int> UpdateAssignmentAsync(ASSIGNMENTS assignment)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Updating Assignment in  database");

            var parameters = new DynamicParameters();
            parameters.Add("@ASSIGNMENTID", assignment.AssignmentId);
            parameters.Add("@TITLE", assignment.Title);
            parameters.Add("@DESCRIPTION", assignment.Description);
            parameters.Add("@DUEDATETIME", assignment.DueDateTime);
            parameters.Add("@FILEPATH", assignment.FilePath);

            return await connection.ExecuteAsync("sp_UpdateAssignment", parameters, commandType: CommandType.StoredProcedure);



        }
    }

   
}
