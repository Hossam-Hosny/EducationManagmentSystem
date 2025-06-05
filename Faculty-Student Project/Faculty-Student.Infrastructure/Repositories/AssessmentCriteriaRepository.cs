using Dapper;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;
using Microsoft.Extensions.Logging;
using System.Data;


namespace Faculty_Student.Infrastructure.Repositories;

internal class AssessmentCriteriaRepository(IDbContext _db, ILogger<AssessmentCriteriaRepository> _logger) : IAssessmentCriteriaRepository
{
    public async Task<int> DeleteCriteriaAsync(int CriteriaId)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Deleting Assessment Criteria  of Id = {CriteriaId}");

            return await connection.ExecuteAsync("sp_DeleteCriteria", new { CRITERIAID = CriteriaId },
                commandType: CommandType.StoredProcedure);


        }
    }

    public async Task<ASSESSMENTCRITERIA?> GetCriteriaByAssignmentAsync(int assignmentId)
    {
        using(var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Criteria of assignment {assignmentId} from database");

            return await connection.QueryFirstOrDefaultAsync<ASSESSMENTCRITERIA>("sp_GetCriteriaByAssignment",
                  new { ASSIGNMENTID = assignmentId },
                     commandType: CommandType.StoredProcedure);


        }
    }

    public async Task<ASSESSMENTCRITERIA?> GetCriteriaByIdAsync(int criteriaId)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Getting Criteria of Id {criteriaId} from database");

            return await connection.QueryFirstOrDefaultAsync<ASSESSMENTCRITERIA>("sp_GetCriteriaById",
                  new { CRITERIAID = criteriaId },
                     commandType: CommandType.StoredProcedure);


        }

    }

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

    public async Task<int> UpdateCriteriaAsync(int MAXSCORE, int CRITERIAID, string CRITERIANAME)
    {
        using (var connection = _db.CreateConnection())
        {
            _logger.LogInformation($"Updating Criteria in  database");

            var parameters = new DynamicParameters();
            parameters.Add("@CRITERIAID", CRITERIAID);
            parameters.Add("@MAXSCORE", MAXSCORE);
            parameters.Add("@CRITERIANAME", CRITERIANAME);


            return await connection.ExecuteAsync("sp_UpdateCriteria", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
