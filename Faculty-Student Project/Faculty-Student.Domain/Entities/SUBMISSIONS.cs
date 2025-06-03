namespace Faculty_Student.Domain.Entities;

public class SUBMISSIONS
{

    public int SubmissionId { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }



}
