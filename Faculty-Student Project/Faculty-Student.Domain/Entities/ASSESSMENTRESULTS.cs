namespace Faculty_Student.Domain.Entities;

public class ASSESSMENTRESULTS
{

    public int ResultId { get; set; }
    public int Score { get; set; }
    public string? Remark { get; set; }
    public int SubmissionId { get; set; }
    public int CriteriaId { get; set; }

}
