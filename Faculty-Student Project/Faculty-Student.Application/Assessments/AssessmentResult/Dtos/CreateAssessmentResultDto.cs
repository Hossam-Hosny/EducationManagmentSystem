namespace Faculty_Student.Application.Assessments.AssessmentResult.Dtos;

public class CreateAssessmentResultDto
{
    public int SubmissionId { get; set; }
    public int CriteriaId { get; set; }
    public int Score { get; set; }
    public string? Remark { get; set; }
}
