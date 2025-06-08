using Faculty_Student.Application.Assessments.AssessmentCriteria.Dtos;
using Faculty_Student.Application.Assessments.AssessmentCriteria.ServiceContracts;
using Faculty_Student.Application.Assessments.AssessmentResult.Dtos;
using Faculty_Student.Application.Assessments.AssessmentResult.ServiceContracts;
using Faculty_Student.Application.Submissions.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    [Authorize(Roles = "Faculty")]
    public class AssessmentController(IAssessmentCriteriaService _criteriaService,IAssessmentResultService _resultService,ISubmissionService _submissionService) : Controller
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
            var submission = await _submissionService.GetByIdAsync(submissionId);
            var criteriaList = await _criteriaService.GetByAssignmentAsync(assignmentId);

            if (submission == null || !criteriaList.Any())
                return NotFound();

            var model = new GradeSubmissionViewModel
            {
                Submission = submission,
                AssignmentId = assignmentId,
                CriteriaList = criteriaList.Select(c => new GradeCriteriaDto
                {
                    CriteriaId = c.CriteriaId,
                    CriteriaName = c.CriteriaName,
                    MaxScore = c.MaxScore
                }).ToList()
            };

            return View(model);
        }

       

        [HttpPost]
        public async Task<IActionResult> SubmitGrades(int submissionId, int assignmentId, List<GradeCriteriaDto> grades)
        {
            foreach (var grade in grades)
            {
                var resultDto = new CreateAssessmentResultDto
                {
                    SubmissionId = submissionId,
                    CriteriaId = grade.CriteriaId,
                    Score = grade.Score,
                    Remark = grade.Remark
                };

                await _resultService.CreateAsync(resultDto);
            }

            return RedirectToAction("ListSubmissionsByAssignmentNo", "Submissions", new { assignmentId });
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
