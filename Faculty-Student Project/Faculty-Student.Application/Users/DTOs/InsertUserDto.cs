using Faculty_Student.Application.Commons.Users;

namespace Faculty_Student.Application.Users.DTOs;

public class InsertUserDto
{

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UsersRoles Role { get; set; } = UsersRoles.Student;

}
