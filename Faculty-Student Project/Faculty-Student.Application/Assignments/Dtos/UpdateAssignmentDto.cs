namespace Faculty_Student.Application.Assignments.Dtos;

public class UpdateAssignmentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime DueDateTime { get; set; }
    public string? FilePath { get; set; }

}
