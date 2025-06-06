using Faculty_Student.Application.Assignments.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    [Authorize(Roles = "Faculty")]
    public class FacultyController() : Controller
    {

        public IActionResult Dashboard()
        {
            return View();
        }




    }
}
