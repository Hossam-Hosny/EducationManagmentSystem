using Faculty_Student.Domain.Entities;

namespace Faculty_Student.Domain.IRepositories;

public interface IAssignmentRepository
{
    Task<int> InsertAssignment(ASSIGNMENTS assignment);

    Task<ASSIGNMENTS?> GetAssignmentByFacultyIdAsync(int facultyId);
    Task<ASSIGNMENTS?> GetAssignmentByIdAsync(int assignmentId);
    Task<int> UpdateAssignmentAsync(ASSIGNMENTS assignment);
    Task<int> DeleteAssignmentAsync(int assignmentId);


}
