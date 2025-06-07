using Faculty_Student.Application.Student.ServiceContracts;
using Faculty_Student.Domain.Dtos;
using Faculty_Student.Domain.IRepositories;

namespace Faculty_Student.Application.Student.Service;

internal class StudentService(IStudentRepository _repo) : IStudentService
{
    public async Task<IEnumerable<StudentSymmaryDto>> GetAllStudentsAsync()
    {
        return await _repo.GetAllStudentsWithSubmissionCountAsync();
    }
}
