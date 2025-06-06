using Faculty_Student.Application.Assignments.Dtos;
using Faculty_Student.Application.Assignments.ServiceContracts;
using Faculty_Student.Domain.Entities;
using Faculty_Student.Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace Faculty_Student.Application.Assignments.Services;

internal class AssignmentServices(IAssignmentRepository _repo, ILogger<AssignmentServices> _logger) : IAssignmentService
{
    public async Task<int> CreateAssignmentAsync(CreateAssignmentDto dto)
    {
        var model = new ASSIGNMENTS
        {
            Title = dto.Title,
            CreatedById = dto.CreatedById,
            Description = dto.Description,
            DueDateTime = dto.DueDateTime,
            FilePath = dto.FilePath
        };
        return await _repo.InsertAssignment(model);
    }

    public async Task<bool> DeleteAssignmentAsync(int assignmentId)
    {
        return await _repo.DeleteAssignmentAsync(assignmentId) > 0;
    }

    public async Task<IEnumerable<AssignmentDto>> GetByFacuyltyIdAsync(int facuyltyId)
    {
        var model = await _repo.GetAssignmentByFacultyIdAsync(facuyltyId);

        return model.Select(a => new AssignmentDto
        {
            Title = a.Title,
            Description = a.Description,
            DueDateTime = a.DueDateTime,
            FilePath = a.FilePath,
            CreatedById = a.CreatedById
            

        });

        
    }

    public async Task<AssignmentDto> GetByIdAsync(int assignmentId)
    {
        var model = await _repo.GetAssignmentByIdAsync(assignmentId);
        if (model is null) return null;

        return new AssignmentDto
        {
            Id = model.AssignmentId,
            CreatedById = model.CreatedById,
            Description = model.Description,
            DueDateTime = model.DueDateTime,
            FilePath = model.FilePath,
            Title = model.Title
        };
    }

   

    public async Task<bool> UpdateAssignmentAsync(UpdateAssignmentDto dot)
    {
        var assignment = new ASSIGNMENTS
        {
           Title = dot.Title,
           Description = dot.Description,
           DueDateTime = dot.DueDateTime,
           FilePath = dot.FilePath
        };


        return await _repo.UpdateAssignmentAsync(assignment) > 0;
    }

   
}
