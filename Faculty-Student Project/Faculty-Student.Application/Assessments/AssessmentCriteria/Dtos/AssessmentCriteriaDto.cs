namespace Faculty_Student.Application.Assessments.AssessmentCriteria.Dtos;

public class AssessmentCriteriaDto
{
    public int CriteriaId { get; set; }
    public int AssignmentId { get; set; }
    public string CriteriaName { get; set; } = string.Empty;
    public int MaxScore { get; set; }
}
