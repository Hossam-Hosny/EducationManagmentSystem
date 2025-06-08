using Dapper;
using Faculty_Student.Domain.Dtos;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class SubmissionRepository(IDbContext _db, ILogger<SubmissionRepository> _logger) : ISubmissionRepository
{
    public async Task<int> DeleteSubmissionAsync(int submissionId)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Deleting Submission of Id = {submissionId}");

            return await connection.ExecuteAsync("sp_DeleteSubmission", new { SUBMISSIONID = submissionId },
                commandType: CommandType.StoredProcedure);


        }
    }

   

    public async Task<List<SUBMISSIONS?>> GetSubmissionByAssignmentIdAsync(int AssignmentId)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Submission of Assignment id  {AssignmentId} from database");

            var result =  await connection.QueryAsync<SUBMISSIONS>("sp_GetSubmissionByAssignment",
                new { ASSIGNMENTID = AssignmentId },
                commandType: CommandType.StoredProcedure);


            return result.ToList();
        }
    }

    public async Task<SUBMISSIONS?> GetSubmissionByIdAsync(int submissionId)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Submission of Id = {submissionId} from database");

            return await connection.QueryFirstOrDefaultAsync<SUBMISSIONS>("sp_GetSubmissionById",
                new { SUBMISSIONID = submissionId },
                commandType: CommandType.StoredProcedure);



        }


    }

   


    public async Task<int> InsertSubmissionAsync(SUBMISSIONS sUBMISSIONS)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation("Inserting Submission into database ");

            var parameters = new DynamicParameters();

            parameters.Add("@ASSIGNMENTID",sUBMISSIONS.AssignmentId);
            parameters.Add("@STUDENTID", sUBMISSIONS.StudentId);
            parameters.Add("@FILEPATH", sUBMISSIONS.FilePath);

            return await connection.ExecuteAsync("sp_InsertSubmission",parameters,commandType:CommandType.StoredProcedure);


        }


    }

    public async Task<int> UpdateSubmissionAsync(int id, string filePath)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Updating submission in  database");

            var parameters = new DynamicParameters();
            parameters.Add("@SUBMISSIONID", id);
            parameters.Add("@FILEPATH", filePath);
            

            return await connection.ExecuteAsync("sp_UpdateSubmission", parameters, commandType: CommandType.StoredProcedure);



        }
    }

    
    
}
