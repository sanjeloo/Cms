using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Manage.Users;
using ViewModels.UI.Account;

namespace Cms.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> signInManager;
        private readonly UserManager<Users> userManager;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel();
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر پیدا نشد");
                return View(model);
            }
            else
            {
                if (await userManager.CheckPasswordAsync(user, model.Password))
                {
                    await signInManager.SignInAsync(user, isPersistent: model.RememberMe);
                    model.ReturnUrl = string.IsNullOrEmpty(model.ReturnUrl) == true ? "/" : model.ReturnUrl;
                    return Redirect(model.ReturnUrl);
                }
                ModelState.AddModelError("", "رمزعبور اشتباه است");
                return View(model);
            }

        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Create() => View();


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
                Photo = model.Photo,
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



    }
}