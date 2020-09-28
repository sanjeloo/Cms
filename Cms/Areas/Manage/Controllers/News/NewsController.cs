using DAL;
using Entities.Entities.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Manage.News;

namespace Cms.Areas.Manage.Controllers.News
{
    [Authorize(Roles = "admin,employe")]
    [Area("Manage")]
    public class NewsController : Controller
    {
        private readonly ApplicationContext db;

        public NewsController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {

            return View(db.News.OrderByDescending(c => c.Id).Where(c => c.IsDelete != true).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> FindToEdit(int id)
        {
            var News = await db.News.FindAsync(id);
            if (News != null)
            {
                return Json(new
                {
                    Title = News.Title,
                    Abstract = News.Abstract,
                    Description = News.Description,
                    Id = News.Id,
                    Photo = News.Photo,
                    Status = 200
                });
            }
            return Json(new
            {
                Status = 404
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(tbl_News model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = 100, //you can see the datails of status code in ~/Global/statusCodes
                    errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                    message = "لطفا در وارد کردن اطلاعات دقت کنید"
                });
            }
            var news = await db.News.FindAsync(model.Id);
            if (news != null)
            {
                news.Title = model.Title;
                news.Abstract = model.Abstract;
                news.Description = model.Description;

                //todo News.Photo = model.Photo;
                if (await db.SaveChangesAsync() == 1)
                    return Json(new
                    {
                        status = 200, //you can see the datails of status code in Global/statusCode 
                        error = 0,
                        message = "خبر با موفقیت ویرایش شد"

                    });
                else
                    return Json(new
                    {
                        status = 600, //you can see the datails of status code in ~/Global/statusCodes
                        errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                        message = "هنگام ویرایش خبر مشکلی رخ داد لطفا بعدا تلاش کنید"
                    });

            }

            return Json(new
            {
                status = 404, //you can see the datails of status code in ~/Global/statusCodes
                errors = 0,
                message = "خبر مورد نظر پیدا نشد"

            });
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CreateNewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = 100, //you can see the datails of status code in ~/Global/statusCodes
                    errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                    message = "لطفا در وارد کردن اطلاعات دقت کنید"
                });
            }
            var News = new tbl_News
            {
                Title = model.Title,
                Abstract = model.Abstract,
                Description = model.Description,
                Photo = model.Photo,
                IsDelete = false,
                CreationDate = DateTime.Now

            };
            //todo sms verification
            try
            {

                await db.News.AddAsync(News);
                var result = await db.SaveChangesAsync();
                    return new JsonResult(new
                    {
                        status = 200, //you can see the datails of status code in Global/statusCode 
                        error = 0,
                        message = "خبر با موفقیت اضافه شد"

                    });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("", e.Message);
                return new JsonResult(new
                {
                    status = 600, //you can see the datails of status code in ~/Global/statusCodes
                    errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                    message = "هنگام افزودن خبر مشکلی رخ داد لطفا بعدا تلاش کنید"
                });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var News = await db.News.FindAsync(id);
            if (News != null)
            {
                News.IsDelete = true;
                var result = await db.SaveChangesAsync();
                return Json(true);

            }
            return Json(false);

        }

    }
}
