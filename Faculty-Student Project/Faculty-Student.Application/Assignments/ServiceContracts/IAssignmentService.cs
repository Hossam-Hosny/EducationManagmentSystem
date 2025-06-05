using Faculty_Student.Application.Assignments.Dtos;

namespace Faculty_Student.Application.Assignments.ServiceContracts;

public interface IAssignmentService
{

    Task<int> CreateAssignmentAsync(CreateAssignmentDto dto);
    Task<AssignmentDto> GetByIdAsync(int assignmentId);
    Task<IEnumerable<AssignmentDto>> GetByFacuyltyIdAsync(int facuyltyId);
    Task<bool> UpdateAssignmentAsync(UpdateAssignmentDto dot);
    Task<bool> DeleteAssignmentAsync(int assignmentId);


}
