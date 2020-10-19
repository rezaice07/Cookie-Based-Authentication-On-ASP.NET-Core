using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPNETCore.CookieAuthentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore.CookieAuthentication.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl="")
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = new Users().UserList().FirstOrDefault(f => f.Email == model.Email);

            if (user == null)
            {
                return View(model);
            }

            var userClaims = new List<Claim>()
            {
                new Claim("Username",user.Username),
                new Claim("UserEmail",user.Email),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.DateOfBirth,user.DateOfBirth)
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity});

            HttpContext.SignInAsync(               
                userPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = model.Rememberme,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8)
                });

            return Redirect("/home/index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/account/login");
        }

        [HttpGet]
        public IActionResult UserAccessDenied()
        {
            return View();
        }

    }
}
