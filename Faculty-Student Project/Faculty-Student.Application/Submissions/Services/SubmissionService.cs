using Faculty_Student.Application.Submissions.Dtos;
using Faculty_Student.Application.Submissions.ServiceContracts;
using Faculty_Student.Domain.IRepositories;

namespace Faculty_Student.Application.Submissions.Services;

internal class SubmissionService(ISubmissionRepository _submissionRepo,IUserRepository _userRepository) : ISubmissionService
{
    public async Task<IEnumerable<SubmissionDto>> GetByAssignmentIdAsync(int assignmentId)
    {
        var submissions = await _submissionRepo.GetSubmissionByAssignmentIdAsync(assignmentId);

        var result = new List<SubmissionDto>();

        foreach (var sub in submissions)
        {
            var student = await _userRepository.GetUserByIdAsync(sub.StudentId);

            result.Add(new SubmissionDto
            {
                SubmissionId = sub.SubmissionId,
                AssignmentId = sub.AssignmentId,
                StudentId = sub.StudentId,
                FilePath = sub.FilePath,
                SubmittedAt = sub.SubmittedAt,
                FullName = student?.UserName ?? "Unknown",
                Email = student?.Email ?? "Unknown"
            });
        }

        return result;
    }
    

    public async Task<SubmissionDto?> GetByIdAsync(int submissionId)
    {

        var submission = await _submissionRepo.GetSubmissionByIdAsync(submissionId);

        if (submission == null)
            return null;

        var student = await _userRepository.GetUserByIdAsync(submission.StudentId);

        return new SubmissionDto
        {
            SubmissionId = submission.SubmissionId,
            AssignmentId = submission.AssignmentId,
            StudentId = submission.StudentId,
            FilePath = submission.FilePath,
            SubmittedAt = submission.SubmittedAt,
            FullName = student?.UserName ?? "Unknown",
            Email = student?.Email ?? "Unknown"
        };
    }
}
