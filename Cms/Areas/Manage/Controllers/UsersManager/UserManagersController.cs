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
                return View(model);
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
                return RedirectToAction("Index");

            else
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> CheckUserName(string username)
        {
            if (!(await userManager.FindByNameAsync(username) != null))
                return Json($"این نام کاربری قبلا در سیستم ثبت شده");

            return Json(false);
           
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
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
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
                        Status = 600

                    });
                }
                return new JsonResult(new
                {
                    Status = 200

                });
            }
            return new JsonResult(new
            {
                Status = 404

            });


        }
    }
}