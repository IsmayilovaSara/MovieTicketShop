using DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Security.Claims;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                RedirectToAction("GetAll", "Product");
                RedirectToAction("GetAll", "AdminProduct");

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(UserDTO user)
        {
            try
            {
                user = _userService.Login(user);

                Authenticate(user);

                return RedirectToAction("GetAll", "Product");
                return RedirectToAction("GetAll", "AdminProduct");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(UserDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Create(user);

                    ViewBag.Success = "User created!";
                    return View(user);
                }
                else
                    return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        private void Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.Username),
                new Claim(ClaimTypes.Role, user.RoleName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }

    }
}
