using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
               if(  await userManager.CheckPasswordAsync(user, model.Password))
                {
                    await signInManager.SignInAsync(user, isPersistent: model.RememberMe);
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

    }
}