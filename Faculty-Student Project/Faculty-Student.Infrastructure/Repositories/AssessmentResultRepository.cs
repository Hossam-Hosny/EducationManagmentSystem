using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class AssessmentResultRepository(IDbContext _db, ILogger<AssessmentResultRepository> _logger) : IAssessmentResultRepository
{
    public async Task<int> DeleteAssessmentResultAsync(int ResultId)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Deleting Assessment Result  of Id = {ResultId}");

            return await connection.ExecuteAsync("sp_DeleteAssessmentResult", new { RESULTID = ResultId },
                commandType: CommandType.StoredProcedure);


        }
    }

    public async Task<ASSESSMENTRESULTS?> GetResultByIdAsync(int resultId)
    {
        using(var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Result of id {resultId} from database");

            return await connection.QueryFirstOrDefaultAsync<ASSESSMENTRESULTS>("sp_GetResultById",
                           new { RESULTID = resultId },
                           commandType: CommandType.StoredProcedure); 


        }
    }

    public async Task<ASSESSMENTRESULTS?> GetResultBySubmissionAsync(int submissionId)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Result of Submission id = {submissionId} from database");


            return await connection.QueryFirstOrDefaultAsync<ASSESSMENTRESULTS>("sp_GetResultBySubmission",
                   new { SUBMISSIONID = submissionId },
                      commandType: CommandType.StoredProcedure);



        }
    }

    public async Task<int> InsertAssessmentResult(ASSESSMENTRESULTS aSSESSMENTRESULTS)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation("Inserting Assessment Result into database ");

            var parameters = new DynamicParameters();

            parameters.Add("@SUBMISSIONID",aSSESSMENTRESULTS.SubmissionId);
            parameters.Add("@CRITERIAID", aSSESSMENTRESULTS.CriteriaId);
            parameters.Add("@SCORE", aSSESSMENTRESULTS.Score);
            parameters.Add("@REMARK", aSSESSMENTRESULTS.Remark);

            return await connection.ExecuteAsync("sp_InsertAssignmentResult", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<int> UpdateAssessmentResultAsync(int resultId, int score, string remark)
    {

        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Updating Result in  database");

            var parameters = new DynamicParameters();
            parameters.Add("@RESULTID", resultId);
            parameters.Add("@SCORE", score);
            parameters.Add("@REMARK", remark);
           

            return await connection.ExecuteAsync("sp_UpdateAssessmentResult", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
