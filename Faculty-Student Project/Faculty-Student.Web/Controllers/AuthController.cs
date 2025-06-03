using Faculty_Student.Application.Users.DTOs;
using Faculty_Student.Application.Users.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Student.Web.Controllers
{
    public class AuthController
        ( IUserServices _userServices
        ) : Controller
    {

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(InsertUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userServices.RegisterUserAsync(model);
            if (result)
                return RedirectToAction("Login");

            ModelState.AddModelError("", "Registration Faild");
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return RedirectToAction("Dashboard", "Home");
        }


    }
}
