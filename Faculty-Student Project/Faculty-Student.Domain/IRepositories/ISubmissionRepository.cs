using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface ISubmissionRepository
{
    Task<int> InsertSubmissionAsync(SUBMISSIONS sUBMISSIONS);

    Task<SUBMISSIONS?> GetSubmissionByAssignmentIdAsync(int AssignmentId);
    Task<SUBMISSIONS?> GetSubmissionByIdAsync(int submissionId);
    Task<int> UpdateSubmissionAsync(int id, string filePath);
    Task<int> DeleteSubmissionAsync(int submissionId);
}
