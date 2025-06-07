using Faculty_Student.Application.Assignments.Dtos;
using Faculty_Student.Application.Assignments.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Faculty_Student.Web.Controllers
{
  //  [Route("[controller]")]
    public class AssignmentsController(IAssignmentService _assignmentService) : Controller
    {
        
        [HttpGet("[action]")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateAssignmentDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            dto.CreatedById = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            await _assignmentService.CreateAssignmentAsync(dto);

            return RedirectToAction("Dashboard","Faculty");



        }

        [HttpGet("[action]")]
        public async Task <IActionResult> GetAll()
        {
            int facultyId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var assignments = await _assignmentService.GetByFacuyltyIdAsync(facultyId);
            return View(assignments);   
        }

        [HttpGet("[action]")]
        public async Task <IActionResult> Edit(int id)
        {
            var assignment = await  _assignmentService.GetByIdAsync (id);
            if (assignment is null) return NotFound();

            var model = new UpdateAssignmentDto
            {
                Title = assignment.Title,
                Description = assignment.Title,
                DueDateTime = assignment.DueDateTime,
                FilePath = assignment.FilePath
            };

            return View(model);

        }

        [HttpPost("[action]")]
        public async Task <IActionResult> Edit (UpdateAssignmentDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _assignmentService.UpdateAssignmentAsync(dto);
            return RedirectToAction("GetAll");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return RedirectToAction("GetAll");
        }

    }
}
