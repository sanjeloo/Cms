using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Areas.PanelAdmin.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        private readonly UserManager<Users> userManager;

        public HomeController(UserManager<Users> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}