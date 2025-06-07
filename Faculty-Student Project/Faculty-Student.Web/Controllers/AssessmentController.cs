using Faculty_Student.Application.Assessments.AssessmentCriteria.Dtos;
using Faculty_Student.Application.Assessments.AssessmentCriteria.ServiceContracts;
using Faculty_Student.Application.Assessments.AssessmentResult.Dtos;
using Faculty_Student.Application.Assessments.AssessmentResult.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    [Authorize(Roles = "Faculty")]
    public class AssessmentController(IAssessmentCriteriaService _criteriaService,IAssessmentResultService _resultService) : Controller
    {

        [HttpGet]
        public async Task <IActionResult> ManageCriteria(int assignmentId)
        {
            ViewBag.AssignmentId = assignmentId;
            var criteria = await _criteriaService.GetByAssignmentAsync(assignmentId);
            return View(criteria);
        }


        [HttpPost]
        public async Task <IActionResult> AddCriteria(CreateAssessmentCriteriaDto dto)
        {

            if (!ModelState.IsValid)
                return RedirectToAction("ManageCriteria", new { assignmentId = dto.AssignmentId });

            await _criteriaService.CreateAsync(dto);
            return RedirectToAction("ManageCriteria", new { assignmentId = dto.AssignmentId });

        }

        [HttpPost]
        public async Task<IActionResult> EditCriteria(UpdateAssessmentCriteriaDto dto)
        {
            await _criteriaService.UpdateAsync(dto);
            return RedirectToAction("ManageCriteria", new { assignmentId = dto.CriteriaId }); // minor trick
        }


        [HttpGet]
        public async Task<IActionResult> DeleteCriteria(int id, int assignmentId)
        {
            await _criteriaService.DeleteAsync(id);
            return RedirectToAction("ManageCriteria", new { assignmentId });
        }

        [HttpGet]
        public async Task<IActionResult> Grade(int submissionId, int assignmentId)
        {
            ViewBag.AssignmentId = assignmentId;
            ViewBag.SubmissionId = submissionId;

            var criteria = await _criteriaService.GetByAssignmentAsync(assignmentId);
            var results = await _resultService.GetBySubmissionAsync(submissionId);

            var gradedCriteriaIds = results.Select(r => r.CriteriaId).ToHashSet();

            var ungraded = criteria.Where(c => !gradedCriteriaIds.Contains(c.CriteriaId)).ToList();

            ViewBag.ExistingResults = results;

            return View(ungraded); 
        }

        [HttpPost]
        public async Task<IActionResult> SubmitGrade(CreateAssessmentResultDto dto, int assignmentId)
        {
            await _resultService.CreateAsync(dto);
            return RedirectToAction("Grade", new { submissionId = dto.SubmissionId, assignmentId });
        }


        [HttpPost]
        public async Task<IActionResult> EditResult(UpdateAssessmentResultDto dto, int submissionId, int assignmentId)
        {
            await _resultService.UpdateAsync(dto);
            return RedirectToAction("Grade", new { submissionId, assignmentId });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteResult(int id, int submissionId, int assignmentId)
        {
            await _resultService.DeleteAsync(id);
            return RedirectToAction("Grade", new { submissionId, assignmentId });
        }

    }
}
