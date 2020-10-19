using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNETCore.CookieAuthentication.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCore.CookieAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "UserPolicy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Consumer")]
        public IActionResult GetConsumerUserRoles()
        {
            return View();
        }

        [Authorize(Roles = "Supplier")]
        public IActionResult GetSupplierUserRoles()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
