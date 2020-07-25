using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Manage.Users;

namespace Cms.Areas.Manage.Controllers.UsersManager
{
    [Area("Manage")]
    public class UserManagersController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly ApplicationContext db;

        public UserManagersController(UserManager<Users> userManager, ApplicationContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }
        public IActionResult IndexAsync()
        {
            var model = new UsersViewModel();
            model.userViewModel = userManager.Users.Where(c => c.Availability).Select(v => new UserViewModel
            {
                FirstName = v.FirstName,
                LastName = v.LastName,
                UserName = v.UserName,
                Photo = v.Photo
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
                return Json(false);
            user.Availability = false;
            await userManager.UpdateAsync(user);
            return Json(true);

        }
        public IActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
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
            var user = new Users
            {
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender
            };
            //todo sms verification
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return new JsonResult(new
                {
                    status = 200, //you can see the datails of status code in Global/statusCode 
                    error = 0,
                    message = "کاربر با موفقیت اضافه شد"

                });

            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return new JsonResult(new
                {
                    status = 600, //you can see the datails of status code in ~/Global/statusCodes
                    errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                    message = "هنگام افزودن کاربر مشکلی رخ داد لطفا بعدا تلاش کنید"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckUserName(string UserName)
        {
            if ((await userManager.FindByNameAsync(UserName) != null))
                return Json($"این نام کاربری قبلا در سیستم ثبت شده");

            return Json(true);

        }

        [HttpPost]
        public async Task<IActionResult> FindUserToEdit(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user != null)
            {
                return new JsonResult(
                   new
                   {
                       Status = 200,
                       user.UserName,
                       user.FirstName,
                       user.LastName,
                       user.PhoneNumber,
                       user.Gender
                   });
            }
            else
            {
                return new JsonResult(
                    new
                    {
                        Status = 404
                    });
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
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

            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;

                var result = await userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return new JsonResult(new
                    {
                        status = 600, //you can see the datails of status code in ~/Global/statusCodes
                        errors = ModelState.Values.Where(e => e.Errors.Count > 0).ToList(),
                        message = "هنگام ویرایش کاربر مشکلی رخ داد لطفا بعدا تلاش کنید"
                    });
                }
                return new JsonResult(new
                {
                    status = 200, //you can see the datails of status code in Global/statusCode 
                    error = 0,
                    message = "کاربر با موفقیت ویرایش شد"

                });
            }
            return new JsonResult(new
            {
                status = 404, //you can see the datails of status code in ~/Global/statusCodes
                errors = 0,
                message = "کاربر مورد نظر پیدا نشد"

            });


        }
    }

    internal class allowhtmlAttribute : Attribute
    {
    }
}