using Faculty_Student.Application.Assignments.Dtos;
using Faculty_Student.Application.Assignments.ServiceContracts;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Microsoft.Extensions.Logging;

namespace Faculty_Student.Application.Assignments.Services;

internal class AssignmentServices(IAssignmentRepository _repo , ILogger<AssignmentServices> _logger) : IAssignmentService
{
    public async Task<int> CreateAssignmentAsync(CreateAssignmentDto dto)
    {
        var assignment = new ASSIGNMENTS
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDateTime = dto.DueDateTime,
            FilePath = dto.FilePath,
            CreatedById = dto.CreatedById
        };


        return await _repo.InsertAssignment(assignment);



    }

    public Task<bool> DeleteAssignmentAsync(int assignmentId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AssignmentDto>> GetByFacuyltyIdAsync(int facuyltyId)
    {
        throw new NotImplementedException();
            
        

    }

    public async Task<AssignmentDto?> GetByIdAsync(int assignmentId)
    {
        var assignment = await _repo.GetAssignmentByIdAsync(assignmentId);

        if (assignment is null) return null;

        var result = new AssignmentDto
        {
            Id = assignment.AssignmentId,
            Description = assignment.Description,
            DueDateTime = assignment.DueDateTime,
            FilePath = assignment.FilePath,
            Title = assignment.Title
        };
        return result;

    }

    public Task<bool> UpdateAssignmentAsync(UpdateAssignmentDto dot)
    {
        throw new NotImplementedException();
    }
}
