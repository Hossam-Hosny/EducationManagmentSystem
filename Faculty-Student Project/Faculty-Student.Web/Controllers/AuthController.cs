using Faculty_Student.Application.Commons.Users;
using Faculty_Student.Application.Users.DTOs;
using Faculty_Student.Application.Users.ServiceContracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Faculty_Student.Web.Controllers
{
    [Route("[controller]")]
    [Route("/")]
    public class AuthController
(
            IUserServices _userServices
) : Controller
    {

        [HttpGet("[action]")]
        public IActionResult Register() => View();

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(InsertUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userServices.RegisterUserAsync(model);
            if (!result)
            {
                ModelState.AddModelError("", "Registration faild");
                return View(model);
            }

            return RedirectToAction("Login");
                

            
        }

        [HttpGet("[action]")]
        public IActionResult Login() => View();

        [HttpPost("[action]")]
        public async Task<IActionResult> Login (UserLoginDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = await _userServices.ValidateUserAsync(dto.Email, dto.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(dto);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.UserId.ToString()),
                new Claim(ClaimTypes.Name , user.Name),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Role , user.Role)
            };


            var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(Identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (user.Role == UsersRoles.Faculty.ToString())
                return RedirectToAction("Dashboard", "Faculty");
            else
                return RedirectToAction("Dashboard", "Student");



        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


    
    }
}
