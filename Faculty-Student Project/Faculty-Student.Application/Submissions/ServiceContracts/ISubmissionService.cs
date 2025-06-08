

using Faculty_Student.Application.Submissions.Dtos;

namespace Faculty_Student.Application.Submissions.ServiceContracts;

public interface ISubmissionService
{
    Task<IEnumerable<SubmissionDto>> GetByAssignmentIdAsync(int assignmentId);
    Task<SubmissionDto?> GetByIdAsync(int submissionId);
}
