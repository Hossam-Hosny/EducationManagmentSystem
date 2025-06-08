namespace Faculty_Student.Application.Submissions.Dtos;

public class SubmissionDto
{

    public int SubmissionId { get; set; }
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }

    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }

    // Optional: grading status
    public bool IsGraded { get; set; }

}
