using DAL;
using Entities.Entities.Articles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Manage.Articles;

namespace Cms.Areas.Manage.Controllers.Articles
{
    [Area("Manage")]
    public class ArticlesController : Controller
    {
        private readonly ApplicationContext db;

        public ArticlesController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {

            return View(db.Articles.OrderByDescending(c => c.Id).Where(c => c.IsDelete != true).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> FindToEdit(int id)
        {
            var article = await db.Articles.FindAsync(id);
            if (article != null)
            {
                return Json(new
                {
                    Title = article.Title,
                    Abstract = article.Abstract,
                    Description = article.Description,
                    Id = article.Id,
                    Photo = article.Photo,
                    Status = 200
                });
            }
            return Json(new
            {
                Status = 404
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(Article model)
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
            var article = await db.Articles.FindAsync(model.Id);
            if (article != null)
            {
                article.Title = model.Title;
                article.Abstract = model.Abstract;
                article.Description = model.Description;

                //todo article.Photo = model.Photo;
                if (await db.SaveChangesAsync() == 1)
                    return Json(new
                    {
                        status = 200, //you can see the datails of status code in Global/statusCode 
                        error = 0,
                        message = "کاربر با موفقیت ویرایش شد"

                    });
                else
                    return Json(new
                    {
                        status = 600, //you can see the datails of status code in ~/Global/statusCodes
                        errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                        message = "هنگام ویرایش کاربر مشکلی رخ داد لطفا بعدا تلاش کنید"
                    });

            }

            return Json(new
            {
                status = 404, //you can see the datails of status code in ~/Global/statusCodes
                errors = 0,
                message = "کاربر مورد نظر پیدا نشد"

            });
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CreateArticleViewModel model)
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
            var article = new Article
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

                await db.Articles.AddAsync(article);
                var result = await db.SaveChangesAsync();
                    return new JsonResult(new
                    {
                        status = 200, //you can see the datails of status code in Global/statusCode 
                        error = 0,
                        message = "مقاله با موفقیت اضافه شد"

                    });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("", e.Message);
                return new JsonResult(new
                {
                    status = 600, //you can see the datails of status code in ~/Global/statusCodes
                    errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                    message = "هنگام افزودن مقاله مشکلی رخ داد لطفا بعدا تلاش کنید"
                });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await db.Articles.FindAsync(id);
            if (article != null)
            {
                article.IsDelete = true;
                var result = await db.SaveChangesAsync();
                return Json(true);

            }
            return Json(false);

        }

    }
}
