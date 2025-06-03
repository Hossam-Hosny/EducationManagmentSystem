using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class SubmissionRepository(IDbContext _db , ILogger<SubmissionRepository> _logger) : ISubmissionRepository
{
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
}
