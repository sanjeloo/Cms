using DAL;
using Entities.Entities.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Manage.Products;

namespace Cms.Areas.Manage.Controllers.Products
{
    [Authorize(Roles = "admin,employe")]
    [Area("Manage")]
    public class ProductsController:Controller
    {
        private readonly ApplicationContext db;

        public ProductsController(ApplicationContext db)
        {
            this.db = db;
        }
        public IActionResult List()
        {

            return View(db.Product.OrderByDescending(c => c.Id).Where(c => c.IsDelete != true).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> FindToEdit(int id)
        {
            var product = await db.Product.FindAsync(id);
            if (product != null)
            {
                return Json(new
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Id = product.Id,
                    Photo = product.Photo,
                    Status = 200
                });
            }
            return Json(new
            {
                Status = 404
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product model)
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
            var product = await db.Product.FindAsync(model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;

                //todo article.Photo = model.Photo;
                if (await db.SaveChangesAsync() == 1)
                    return Json(new
                    {
                        status = 200, //you can see the datails of status code in Global/statusCode 
                        error = 0,
                        message = "محصول با موفقیت ویرایش شد"

                    });
                else
                    return Json(new
                    {
                        status = 600, //you can see the datails of status code in ~/Global/statusCodes
                        errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                        message = "هنگام ویرایش محصول مشکلی رخ داد لطفا بعدا تلاش کنید"
                    });

            }

            return Json(new
            {
                status = 404, //you can see the datails of status code in ~/Global/statusCodes
                errors = 0,
                message = "محصول مورد نظر پیدا نشد"

            });
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CreateProductViewModel model)
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
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Photo = model.Photo,
                IsDelete = false,
                CreateDate = DateTime.Now

            };
            //todo sms verification
            try
            {

                await db.Product.AddAsync(product);
                var result = await db.SaveChangesAsync();
                return new JsonResult(new
                {
                    status = 200, //you can see the datails of status code in Global/statusCode 
                    error = 0,
                    message = "محصول با موفقیت اضافه شد"

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
            var product = await db.Product.FindAsync(id);
            if (product != null)
            {
                product.IsDelete = true;
                var result = await db.SaveChangesAsync();
                return Json(true);
            }
            return Json(false);

        }
    }
}
