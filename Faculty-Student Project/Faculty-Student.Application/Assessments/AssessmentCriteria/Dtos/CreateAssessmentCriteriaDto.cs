namespace Faculty_Student.Application.Assessments.AssessmentCriteria.Dtos;

public class CreateAssessmentCriteriaDto
{
    public int AssignmentId { get; set; }
    public string CriteriaName { get; set; } = string.Empty;
    public int MaxScore { get; set; }

}
