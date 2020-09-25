//using Entities.Entities.UserAndSecurity;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ViewModels.Manage.Users.Account;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;

//namespace Cms.Areas.Manage.Controllers.UsersManager
//{
//    [Authorize(Roles = "admin,employe")]
//    [Area("Manage")]
//    public class AccountController : Controller
//    {
//        private readonly UserManager<Users> userManager;
//        private readonly SignInManager<Users> signInManager;
//        private readonly RoleManager<IdentityRole> rolemanager;

//        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<IdentityRole> rolemanager)
//        {
//            this.userManager = userManager;
//            this.signInManager = signInManager;
//            this.rolemanager = rolemanager;
//        }

//        public async Task<IActionResult> ManageUserClaims(string userid)
//        {
//            var user = await userManager.FindByIdAsync(userid);
//            if (user == null)
//            {
//                return View("NotFound");
//            }
//            var model = new UserClaimsViewModel()
//            {
//                UserId = userid
//            };

//            IList<Claim> existingClaims = await userManager.GetClaimsAsync(user);

//            foreach (var claim in ClaimsStore.AllClaims)
//            {
//                UserClaim userClaim = new UserClaim()
//                {
//                    ClaimType = claim.Type,

//                };

//                //if the user has the claim is select property set to true ,,, so checkbox next to the claim name is checked
//                if (existingClaims.Any(c => c.Type == claim.Type))
//                    userClaim.IsSelected = true;

//                model.Claims.Add(userClaim);
//            }
//            return View(model);
//        }


//        [HttpPost]
//        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model)
//        {
//            var user = await userManager.FindByIdAsync(model.UserId);
//            if (user == null)
//            {
//                return View("NotFound");
//            }
//            var claims = await userManager.GetClaimsAsync(user);
//            var result = await userManager.RemoveClaimsAsync(user, claims);
//            if (!result.Succeeded)
//            {
//                foreach (var error in result.Errors)
//                {

//                    ModelState.AddModelError("", error.Description);
//                }
//            }
//            //select list of claims that selected in ui to add in user claims
//            result = await userManager.AddClaimsAsync(user, model.Claims.Where(c => c.IsSelected)
//                .Select(v => new Claim(v.ClaimType, "True")));
//            if (!result.Succeeded)
//            {
//                foreach (var error in result.Errors)
//                {

//                    ModelState.AddModelError("", error.Description);
//                }
//            }
//            return Redirect($"/Account/Edit?id={model.UserId}");
//        }

//        public IActionResult CreateUser()
//        {
//            return View();
//        }
      
      
//        //public async Task<IActionResult> Edit(string Id)
//        //{
//        //    var user = await userManager.FindByIdAsync(Id);
//        //    if (user != null)
//        //    {
//        //        var x = new EditUserViewModel
//        //        {
//        //            Email = user.Email,
//        //            EmailConfirmed = user.EmailConfirmed,
//        //            FirstName = user.FirstName,
//        //            UserName = user.UserName,
//        //            Id = user.Id
//        //        };
//        //        x.Roles = await userManager.GetRolesAsync(user);
//        //        IList<Claim> existingClaims = await userManager.GetClaimsAsync(user);
//        //        x.Claims = existingClaims.Select(c => c.Type).ToList();

//        //        return View(x);
//        //    }
//        //    return View("NotFound");
//        //}
//        //todo edit for tara
//        //todo details for tara
//        // todo Delete
//        //public IActionResult Login(string ReturnUrl)
//        //{
//        //    var model = new LoginViewModel();
//        //    return View(model);
//        //}
//        //[HttpPost]
//        //public async Task<IActionResult> Login(LoginViewModel model)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return View(model);
//        //    }

//        //    var user = await userManager.FindByNameAsync(model.UserName);
//        //    if (user == null)
//        //    {
//        //        ModelState.AddModelError("", "نام کاربری در سیستم وجود ندارد");
//        //        return View(model);
//        //    }
//        //    else
//        //    {
//        //        if (await userManager.CheckPasswordAsync(user, model.Password))
//        //        {
//        //            await signInManager.SignInAsync(user, isPersistent: model.RememberMe);
//        //            return Redirect("/");
//        //        }
//        //        ModelState.AddModelError("", "رمز ورود اشتباه است");
//        //        return View(model);
//        //    }
//        //}
       
//        //public async Task<IActionResult> EditUserRoles(string userid)
//        //{
//        //    var user = await userManager.FindByIdAsync(userid);
//        //    if (user == null)
//        //    {
//        //        return View("NotFound");
//        //    }
//        //    var model = new List<EditRolesForUserViewModel>();
//        //    foreach (var role in rolemanager.Roles.ToList())
//        //    {
//        //        var item = new EditRolesForUserViewModel();
//        //        item.RoleName = role.Name;

//        //        if (await userManager.IsInRoleAsync(user, role.Name))
//        //        {
//        //            item.IsSelected = true;
//        //        }


//        //        model.Add(item);

//        //    }
//        //    ViewBag.UserId = userid;
//        //    return View(model);
//        //}
//        //[HttpPost]
//        //public async Task<IActionResult> EditUserRoles(List<EditRolesForUserViewModel> model, string userid)
//        //{
//        //    var user = await userManager.FindByIdAsync(userid);
//        //    if (user == null)
//        //    {
//        //        return View("NotFound");
//        //    }
//        //    foreach (var item in model)
//        //    {
//        //        var role = await rolemanager.FindByNameAsync(item.RoleName);
//        //        IdentityResult result = null;
//        //        if (item.IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
//        //        {
//        //            result = await userManager.AddToRoleAsync(user, role.Name);
//        //            if (!result.Succeeded)
//        //            {
//        //                foreach (var error in result.Errors)
//        //                {

//        //                    ModelState.AddModelError("", error.Description);
//        //                }
//        //            }
//        //        }
//        //        else if (!item.IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
//        //        {
//        //            result = await userManager.RemoveFromRoleAsync(user, role.Name);
//        //            if (!result.Succeeded)
//        //            {
//        //                foreach (var error in result.Errors)
//        //                {

//        //                    ModelState.AddModelError("", error.Description);
//        //                }
//        //            }

//        //        }



//        //    }
//        //    return RedirectToAction("Edit", new { id = userid });
//        //    //end----
//        //    //return Redirect($"/Account/Edit?id={userid}");
//        //}
//        public IActionResult AccessDenied()
//        {
//            return View();
//        }
//    }
//}
