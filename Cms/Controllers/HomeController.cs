using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cms.Models;
using Microsoft.AspNetCore.Identity;
using Entities.Entities.UserAndSecurity;

namespace Cms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Users> userManager;

        public HomeController(ILogger<HomeController> logger,UserManager<Users> userManager)
        {
            _logger = logger;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = userManager.Users.ToList();
            return View(model);
        }

        public IActionResult Privacy()
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
