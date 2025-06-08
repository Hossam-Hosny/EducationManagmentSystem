using Faculty_Student.Application.Submissions.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    [Authorize(Roles ="Faculty")]
    public class SubmissionsController(ISubmissionService _submissionService) : Controller
    {


        [HttpGet("[action]")]
        public async Task<IActionResult> Details(int submissionId)
        {
            var submission = await _submissionService.GetByIdAsync(submissionId);

            if (submission == null)
                return NotFound();

            return View(submission);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ListSubmissionsByAssignmentNo(int assignmentId)
        {
            var result =await _submissionService.GetByAssignmentIdAsync(assignmentId);

            if (result is null) return null;

            ViewBag.AssignmentId = assignmentId;

            return View(result);


        }

    }
}
