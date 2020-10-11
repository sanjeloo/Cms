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

        [HttpPost]
        public async Task<IActionResult> NewsLetter(string Phone)
        {
            try
            {
                if (Phone.Length == 11)
                {

                    if (!db.NewsLetter.Any(c => c.Mobile == Phone))
                    {
                        await db.NewsLetter.AddAsync(new Entities.Entities.NewsLetters.NewsLetter() { Mobile = Phone, CreationDate = DateTime.Now });
                       await db.SaveChangesAsync();
                        return Json(new
                        {
                            status = 200, //you can see the datails of status code in Global/statusCode 
                            error = 0,
                            message = "شما با موفقیت در خبرنامه عضو شدید از اینکه باما همراه هستید سپاسگزاریم"

                        });
                    }

                    else
                        return Json(new
                        {
                            status = 600, //you can see the datails of status code in ~/Global/statusCodes
                            errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                            message = "کاربر گرامی این شماره قبلا در سیستم ثبت شده است"
                        });
                }
                else
                    return Json(new
                    {
                        status = 100, //you can see the datails of status code in ~/Global/statusCodes
                        errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                        message = "لطفا در وارد کردن اطلاعات دقت کنید"
                    });

            }
            catch (Exception e)
            {
                return Json(new
                {
                    status = 100, //you can see the datails of status code in ~/Global/statusCodes
                    errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                    message = "لطفا در وارد کردن اطلاعات دقت کنید"
                });
            }

        }
    }
}
