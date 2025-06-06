using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
