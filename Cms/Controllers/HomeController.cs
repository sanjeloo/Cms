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
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace Cms.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Users> userManager;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, UserManager<Users> userManager, ApplicationContext db)
        {
            _logger = logger;
            this.userManager = userManager;
            this.db = db;
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
        public IActionResult ProductDetails(int id)
        {
            var model = db.Product.Find(id);
            return View(model);
        }
        public IActionResult NewsDetails(int id)
        {
            var model = db.News.Find(id);
            return View(model);
        }
        public IActionResult ArticleDetails(int id)
        {
            var model = db.Articles.Find(id);
            return View(model);
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult ListProduct()
        {
            var model = db.Product.Where(c => c.IsDelete != true).OrderByDescending(c => c.Id);
            return View(model);
        }

        public IActionResult ListNews()
        {
            var model = db.News.Where(c => c.IsDelete != true).OrderByDescending(c => c.Id);
            return View(model);
        }
        public IActionResult ListArticles()
        {
            var model = db.Articles.Where(c => c.IsDelete != true).OrderByDescending(c => c.Id);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
