using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IAssignmentRepository
{
    Task<int> InsertAssignment(ASSIGNMENTS assignment);
}
