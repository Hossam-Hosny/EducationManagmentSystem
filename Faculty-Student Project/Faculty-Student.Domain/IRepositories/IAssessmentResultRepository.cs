using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IAssessmentResultRepository
{
    Task<int> InsertAssessmentResult(ASSESSMENTRESULTS aSSESSMENTRESULTS);

    Task<ASSESSMENTRESULTS?> GetResultBySubmissionAsync(int submissionId);
    Task<ASSESSMENTRESULTS?> GetResultByIdAsync(int resultId);
    Task<int> UpdateAssessmentResultAsync(int resultId, int score , string remark);
    Task<int> DeleteAssessmentResultAsync(int ResultId);



}
