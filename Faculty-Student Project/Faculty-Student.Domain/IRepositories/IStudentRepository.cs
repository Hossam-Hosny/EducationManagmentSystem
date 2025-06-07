using Faculty_Student.Domain.Dtos;

namespace Faculty_Student.Domain.IRepositories;

public interface IStudentRepository
{
  Task<IEnumerable<StudentSymmaryDto>> GetAllStudentsWithSubmissionCountAsync();

}
