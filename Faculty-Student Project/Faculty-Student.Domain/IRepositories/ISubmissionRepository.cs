using Faculty_Student.Domain.Dtos;
using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface ISubmissionRepository
{
    Task<int> InsertSubmissionAsync(SUBMISSIONS sUBMISSIONS);

    Task<List<SUBMISSIONS>?> GetSubmissionByAssignmentIdAsync(int AssignmentId);
    Task<SUBMISSIONS?> GetSubmissionByIdAsync(int submissionId);
    Task<int> UpdateSubmissionAsync(int id, string filePath);
    Task<int> DeleteSubmissionAsync(int submissionId);
   
}
