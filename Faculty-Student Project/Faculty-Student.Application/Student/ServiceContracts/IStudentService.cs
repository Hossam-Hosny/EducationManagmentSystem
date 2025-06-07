using Faculty_Student.Domain.Dtos;

namespace Faculty_Student.Application.Student.ServiceContracts;

public interface IStudentService
{
    Task<IEnumerable<StudentSymmaryDto>> GetAllStudentsAsync();

}
