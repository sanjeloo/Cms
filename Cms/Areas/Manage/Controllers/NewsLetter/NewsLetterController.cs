using DAL;
using Entities.Entities.NewsLetters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsefullClasses;

namespace Cms.Areas.Manage.Controllers.NewsLetters
{
    [Authorize(Roles = "admin,employe")]
    [Area("Manage")]
    public class NewsLetterController : Controller
    {
        private readonly ApplicationContext db;

        public NewsLetterController(ApplicationContext db)
        {
            this.db = db;
        }


        public IActionResult List() => View(db.NewsLetter.OrderByDescending(c => c.Id).ToList());

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var newsletter = await db.NewsLetter.FindAsync(id);
            if (newsletter != null)
            {
                db.NewsLetter.Remove(newsletter);
                var result = await db.SaveChangesAsync();
                return Json(true);
            }
            return Json(false);

        }
        public async Task<IActionResult> Send(string message)
        {
            try
            {

                string result = EmailAndSms.SendSms(message, "09366733490");
                return Json(new { status = 200, message = "پیامک با موفقیت ارسال گردید" });
            }
            catch (Exception e)
            {
                return Json(new { status = 500, message = "خطایی در هنگام ارسال پیامک رخ داد" });
            }
        }


    }
}
