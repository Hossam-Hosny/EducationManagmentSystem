using Faculty_Student.Application.Assessments.AssessmentResult.Dtos;
using Faculty_Student.Application.Assessments.AssessmentResult.ServiceContracts;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;

namespace Faculty_Student.Application.Assessments.AssessmentResult.Services;

internal class AssessmentResultService(IAssessmentResultRepository _repo) : IAssessmentResultService
{
    public async Task<int> CreateAsync(CreateAssessmentResultDto dto)
    {
        var entity = new ASSESSMENTRESULTS
        {
            SubmissionId = dto.SubmissionId,
            CriteriaId = dto.CriteriaId,
            Score = dto.Score,
            Remark = dto.Remark
        };
        return await _repo.InsertAssessmentResult(entity);
    }

    public async Task<bool> DeleteAsync(int resultId)
    {
        return await _repo.DeleteAssessmentResultAsync(resultId) > 0;
    }

    public async Task<AssessmentResultDto?> GetByIdAsync(int resultId)
    {
        var r = await _repo.GetResultByIdAsync(resultId);
        return r == null ? null : new AssessmentResultDto
        {
            ResultId = r.ResultId,
            SubmissionId = r.SubmissionId,
            CriteriaId = r.CriteriaId,
            Score = r.Score,
            Remark = r.Remark
        };
    }

    public async Task<IEnumerable<AssessmentResultDto>> GetBySubmissionAsync(int submissionId)
    {
        var list = await _repo.GetResultBySubmissionAsync(submissionId);
        return list.Select(r => new AssessmentResultDto
        {
            ResultId = r.ResultId,
            SubmissionId = r.SubmissionId,
            CriteriaId = r.CriteriaId,
            Score = r.Score,
            Remark = r.Remark
        });
    }

    public async Task<bool> UpdateAsync(UpdateAssessmentResultDto dto)
    {
      
        return await _repo.UpdateAssessmentResultAsync(dto.ResultId,dto.Score,dto.Remark!) > 0;
    }
}
