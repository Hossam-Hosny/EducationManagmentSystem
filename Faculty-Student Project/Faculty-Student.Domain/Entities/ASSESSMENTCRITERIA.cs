namespace Faculty_Student.Domain.Entities;

public class ASSESSMENTCRITERIA
{ 

    public int CriteriaId { get; set; }
    public string CriteriaName { get; set; } = string.Empty;
    public int MaxScore { get; set; }
    public int AssignmentId { get; set; }

}
