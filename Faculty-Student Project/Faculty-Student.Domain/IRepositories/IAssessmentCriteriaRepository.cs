using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IAssessmentCriteriaRepository
{
    Task<int> InsertAssessmentCriteria(ASSESSMENTCRITERIA aSSESSMENTCRITERIA);

    Task<List<ASSESSMENTCRITERIA?>> GetCriteriaByAssignmentAsync(int assignmentId);
    Task<ASSESSMENTCRITERIA?> GetCriteriaByIdAsync(int criteriaId);
    Task<int> UpdateCriteriaAsync(int @MAXSCORE, int @CRITERIAID, string @CRITERIANAME);
    Task<int> DeleteCriteriaAsync(int CriteriaId);


}
