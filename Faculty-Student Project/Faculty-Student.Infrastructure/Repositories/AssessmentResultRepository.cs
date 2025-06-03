using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class AssessmentResultRepository(IDbContext _db,ILogger<AssessmentResultRepository> _logger) : IAssessmentResultRepository
{
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
}
