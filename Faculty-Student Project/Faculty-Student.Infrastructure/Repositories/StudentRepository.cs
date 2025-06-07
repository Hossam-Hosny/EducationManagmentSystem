using Dapper;
using Faculty_Student.Application.Student.Dto;
using Faculty_Student.Domain.Dtos;
using Faculty_Student.Domain.IRepositories;
using Faculty_Student.Infrastructure.DbContext;


namespace Faculty_Student.Infrastructure.Repositories;

internal class StudentRepository(IDbContext _db) : IStudentRepository
{
    public async Task<IEnumerable<StudentSymmaryDto>> GetAllStudentsWithSubmissionCountAsync()
    {
        var sql = @"
        SELECT 
            u.UserId, u.UserName, u.Email, 
            COUNT(s.SubmissionId) AS SubmissionCount
        FROM Users u
        LEFT JOIN Submissions s ON u.UserId = s.StudentId
        WHERE u.Role = 'Student'
        GROUP BY u.UserId, u.UserName, u.Email
        ORDER BY u.UserName;
    ";

        using( var connection = _db.CreateConnection())
        {
            return await connection.QueryAsync<StudentSymmaryDto>(sql);
        }
        
    }
}
