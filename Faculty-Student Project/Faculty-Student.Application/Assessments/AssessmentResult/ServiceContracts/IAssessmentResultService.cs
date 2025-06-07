using Faculty_Student.Application.Assessments.AssessmentResult.Dtos;

namespace Faculty_Student.Application.Assessments.AssessmentResult.ServiceContracts;

public interface IAssessmentResultService
{
    Task<int> CreateAsync(CreateAssessmentResultDto dto);
    Task<IEnumerable<AssessmentResultDto>> GetBySubmissionAsync(int submissionId);
    Task<AssessmentResultDto?> GetByIdAsync(int resultId);
    Task<bool> UpdateAsync(UpdateAssessmentResultDto dto);
    Task<bool> DeleteAsync(int resultId);
}
