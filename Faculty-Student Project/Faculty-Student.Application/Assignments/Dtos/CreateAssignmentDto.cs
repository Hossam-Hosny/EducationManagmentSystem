namespace Faculty_Student.Application.Assignments.Dtos;

public class CreateAssignmentDto
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime DueDateTime { get; set; }
    public string? FilePath { get; set; }
    public int CreatedById { get; set; }
}
