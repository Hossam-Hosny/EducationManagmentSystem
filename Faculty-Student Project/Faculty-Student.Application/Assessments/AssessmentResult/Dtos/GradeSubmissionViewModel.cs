using Faculty_Student.Application.Submissions.Dtos;

namespace Faculty_Student.Application.Assessments.AssessmentResult.Dtos;

public class GradeSubmissionViewModel
{
    public SubmissionDto Submission { get; set; } = new();
    public int AssignmentId { get; set; }

    public List<GradeCriteriaDto> CriteriaList { get; set; } = new();

}
