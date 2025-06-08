namespace Faculty_Student.Application.Assessments.AssessmentResult.Dtos;

public class GradeCriteriaDto
{
    public int CriteriaId { get; set; }
    public string CriteriaName { get; set; } = string.Empty;
    public int MaxScore { get; set; }

    public int Score { get; set; }         
    public string? Remark { get; set; }
}
