namespace Faculty_Student.Domain.Entities;

public class ASSIGNMENTS
{

    public int AssignmentId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime DueDateTime { get; set; }
    public string? FilePath { get; set; }
    public int CreatedById { get; set; }


    

}
