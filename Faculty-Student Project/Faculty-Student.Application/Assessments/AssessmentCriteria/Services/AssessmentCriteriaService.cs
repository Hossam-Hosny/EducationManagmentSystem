using Faculty_Student.Application.Assessments.AssessmentCriteria.Dtos;
using Faculty_Student.Application.Assessments.AssessmentCriteria.ServiceContracts;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;

namespace Faculty_Student.Application.Assessments.AssessmentCriteria.Services;

internal class AssessmentCriteriaService(IAssessmentCriteriaRepository _repo) : IAssessmentCriteriaService
{
    public async Task<int> CreateAsync(CreateAssessmentCriteriaDto dto)
    {
        var entity = new ASSESSMENTCRITERIA
        {
            AssignmentId = dto.AssignmentId,
            CriteriaName = dto.CriteriaName,
            MaxScore = dto.MaxScore
        };
        return await _repo.InsertAssessmentCriteria(entity);
    }

    public async Task<bool> DeleteAsync(int criteriaId)
    {
       return await _repo.DeleteCriteriaAsync(criteriaId) > 0;
    }

    public async Task<IEnumerable<AssessmentCriteriaDto>> GetByAssignmentAsync(int assignmentId)
    {
        var list = await _repo.GetCriteriaByAssignmentAsync(assignmentId);

        return list.Select(c => new AssessmentCriteriaDto
        {
            CriteriaId = c.CriteriaId,
            AssignmentId = c.AssignmentId,
            CriteriaName = c.CriteriaName,
            MaxScore = c.MaxScore
        });
    }

    public async Task<AssessmentCriteriaDto?> GetByIdAsync(int criteriaId)
    {
        var c = await _repo.GetCriteriaByIdAsync(criteriaId);
        return c == null ? null : new AssessmentCriteriaDto
        {
            CriteriaId = c.CriteriaId,
            AssignmentId = c.AssignmentId,
            CriteriaName = c.CriteriaName,
            MaxScore = c.MaxScore
        };
    }

    public async Task<bool> UpdateAsync(UpdateAssessmentCriteriaDto dto)
    {
       
        return await _repo.UpdateCriteriaAsync(dto.MaxScore,dto.CriteriaId,dto.CriteriaName) > 0;
    }
}
