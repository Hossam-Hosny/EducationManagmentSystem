using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    public class HomeController : Controller
    {
    
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }

}

