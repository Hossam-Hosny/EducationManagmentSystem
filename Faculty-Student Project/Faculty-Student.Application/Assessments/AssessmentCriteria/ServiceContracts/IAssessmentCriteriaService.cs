using Faculty_Student.Application.Assessments.AssessmentCriteria.Dtos;

namespace Faculty_Student.Application.Assessments.AssessmentCriteria.ServiceContracts;

public interface IAssessmentCriteriaService
{
    Task<int> CreateAsync(CreateAssessmentCriteriaDto dto);
    Task<IEnumerable<AssessmentCriteriaDto>> GetByAssignmentAsync(int assignmentId);
    Task<AssessmentCriteriaDto?> GetByIdAsync(int criteriaId);
    Task<bool> UpdateAsync(UpdateAssessmentCriteriaDto dto);
    Task<bool> DeleteAsync(int criteriaId);
}
