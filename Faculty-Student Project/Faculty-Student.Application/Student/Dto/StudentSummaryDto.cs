namespace Faculty_Student.Application.Student.Dto;

public class StudentSummaryDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int SubmissionCount { get; set; }

}
