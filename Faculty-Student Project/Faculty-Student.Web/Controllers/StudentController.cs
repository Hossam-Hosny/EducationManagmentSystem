using Faculty_Student.Application.Student.ServiceContracts;
using Faculty_Student.Application.Users.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
   
    [Authorize(Roles ="Faculty")]
    public class StudentController(IStudentService _studentService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }





    }
}
