using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Faculty_Student.Infrastructure.Repositories;

internal class AssessmentCriteriaRepository(IDbContext _db , ILogger<AssessmentCriteriaRepository> _logger) : IAssessmentCriteriaRepository
{
    public async Task<int> InsertAssessmentCriteria(ASSESSMENTCRITERIA aSSESSMENTCRITERIA)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation("Inserting Assignment Criteria into database ");

            var parameters = new DynamicParameters();

            parameters.Add("@ASSIGNMENTID",aSSESSMENTCRITERIA.AssignmentId);
            parameters.Add("@CRITERIANAME", aSSESSMENTCRITERIA.CriteriaName);
            parameters.Add("@MAXSCORE", aSSESSMENTCRITERIA.MaxScore);

            return await connection.ExecuteAsync("sp_InsertAssignmentCriteria", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
