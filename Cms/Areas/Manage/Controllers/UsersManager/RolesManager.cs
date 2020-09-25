using Entities.Entities.UserAndSecurity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Manage.Users.Roles;

namespace Cms.Areas.Manage.Controllers.UsersManager
{
    [Area("Manage")]
    [Authorize(Roles = "admin")]
    public class RolesManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Users> usermanager;

        public RolesManagerController(RoleManager<IdentityRole> roleManager, UserManager<Users> usermanager)
        {
            this.roleManager = roleManager;
            this.usermanager = usermanager;
        }
        public IActionResult RolesList()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            var model = new CreateRoleViewModel();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            IdentityRole role = new IdentityRole()
            {
                Name = model.RoleName
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("RolesList");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

        }
        //[Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var Model = new EditRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,



            };
            foreach (var item in usermanager.Users.ToList())
            {

                var Result = await usermanager.IsInRoleAsync(item, role.Name);
                if (Result)
                {
                    Model.UserName.Add(item.UserName);
                }

            }
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel X)
        {

            var role = await roleManager.FindByIdAsync(X.RoleId);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                role.Name = X.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    foreach (var errore in result.Errors)
                    {
                        ModelState.AddModelError("", errore.Description);
                    }

                }

                return View(X);
            }


        }
        public async Task<IActionResult> EditUserRole(string roleid)
        {
            var role = await roleManager.FindByIdAsync(roleid);
            if (role == null)
            {
                return View("NotFound");
            }
            List<EditUserRoleViewModel> model = new List<EditUserRoleViewModel>();
            foreach (var user in usermanager.Users.ToList())
            {
                var item = new EditUserRoleViewModel();
                item.UserName = user.UserName;

                if (await usermanager.IsInRoleAsync(user, role.Name))
                {
                    item.IsSelected = true;
                }
                else
                {
                    item.IsSelected = false;
                }

                model.Add(item);

            }
            ViewBag.RoleId = roleid;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRole(List<EditUserRoleViewModel> model, string roleid)
        {
            var role = await roleManager.FindByIdAsync(roleid);
            if (role == null)
            {
                return View("NotFound");
            }
            foreach (var item in model)
            {
                var user = await usermanager.FindByNameAsync(item.UserName);
                IdentityResult result = null;
                if (item.IsSelected && !(await usermanager.IsInRoleAsync(user, role.Name)))
                {
                    result = await usermanager.AddToRoleAsync(user, role.Name);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {

                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else if (!item.IsSelected && (await usermanager.IsInRoleAsync(user, role.Name)))
                {
                    result = await usermanager.RemoveFromRoleAsync(user, role.Name);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {

                            ModelState.AddModelError("", error.Description);
                        }
                    }

                }



            }
            return Redirect($"/Manage/RolesManager/Edit?id={roleid}");
        }


        //[Authorize(Policy = "DeleteRolePolicy")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("NotFound");
            }
            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("RolesList");
        }

    }
}
