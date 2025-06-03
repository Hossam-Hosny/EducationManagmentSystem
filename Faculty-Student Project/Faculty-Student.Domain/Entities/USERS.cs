namespace Faculty_Student.Domain.Entities;

public class USERS
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty ;
    public string PasswordHash {  get; set; } = string.Empty ;
    public string Role { get; set; } = string.Empty ;
    public DateTime CreatedAt { get; set; }
}
