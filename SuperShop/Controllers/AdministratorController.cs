using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SuperShop.Database;
using SuperShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperShop.Controllers
{
    //[Authorize(Policy = "ReolePermission")]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        SuperShopDbContext _db;

        // GET: /<controller>/

        public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SuperShopDbContext db)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _db = db;
        }

        [HttpGet]
        [Authorize(Policy = "ReolePermission")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdministratorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult identityResult = await roleManager.CreateAsync(role);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("List");
                }
                foreach(IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult List()
        {
            var role = roleManager.Roles;
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {id} can not be found";
                return View("NotFound");
            }
            var model = new AdministratorEditViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            //foreach (var user in userManager.Users)
            //{
            //    var userRoleViewModel = new UserRoleViewModel
            //    {
            //        UserId = user.Id,
            //        UserName = user.UserName
            //    };
            //    if (await userManager.IsInRoleAsync(user, role.Name))
            //    {
            //        userRoleViewModel.IsSelected = true;
            //    }
            //    else
            //    {
            //        userRoleViewModel.IsSelected = false;
            //    }
            //}
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {id} can not be found";
                return View("NotFound");
            }
            var model = new AdministratorEditViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            //foreach(var user in userManager.Users)
            //{
            //    if(await userManager.IsInRoleAsync(user, role.Name))
            //    {
            //        model.Users.Add(user.UserName);
            //    }
            //}
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdministratorEditViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMesseage = $"This id {model.Id} can not be found";
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        //[Authorize ("Admin")]
        public async Task<IActionResult> EditUserInRole(string roleid)
        {
            ViewBag.roleId = roleid;
            var role = await roleManager.FindByIdAsync(roleid);
            if (role == null)
            {
                ViewBag.ErrorMesseage = $"Role with {roleid} not found";
                return View("NotFound");
            }
            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                //foreach(var error in result.Errors)
                //{
                //    ModelState.AddModelError(""+error.Description);
                //}
                return Ok();
            }
        }

        [HttpGet]
        public async Task<IActionResult> AssignUser()
        {
            UserAssignVM userAssign = new UserAssignVM();
            userAssign.UserList = userManager.Users
                                    .Select(IdentityUser => new SelectListItem() {
                                        Text = IdentityUser.UserName,
                                        Value = IdentityUser.Id.ToString()
                                    }).ToList();

            userAssign.RoleList = roleManager.Roles
                                    .Select(IdentityRole => new SelectListItem()
                                    {
                                        Text = IdentityRole.Name,
                                        Value = IdentityRole.Id.ToString()
                                    }).ToList();
            return View(userAssign);
        }

        [HttpPost]
        public async Task<IActionResult> AssignUser(UserAssignVM userAssign)
        {
            var user = await userManager.FindByIdAsync(userAssign.UserId);
            var role = await roleManager.FindByIdAsync(userAssign.RoleId);
            if(await userManager.IsInRoleAsync(user, role.Name))
            {
                
                return Json($"{user} already Assigned");
            }
            else
            {
                var assign = await userManager.AddToRoleAsync(user, role.Name);
                if (assign.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    UserAssignVM model = new UserAssignVM();
                    userAssign.UserList = userManager.Users
                                            .Select(IdentityUser => new SelectListItem()
                                            {
                                                Text = IdentityUser.UserName,
                                                Value = IdentityUser.Id.ToString()
                                            }).ToList();

                    userAssign.RoleList = roleManager.Roles
                                            .Select(IdentityRole => new SelectListItem()
                                            {
                                                Text = IdentityRole.Name,
                                                Value = IdentityRole.Id.ToString()
                                            }).ToList();
                    return View(model);
                }
            }
        }




        //[HttpGet]
        //public async Task<IActionResult> Assign(string roleId)
        //{
        //    ViewBag.roleId = roleId;
        //    var role = await roleManager.FindByIdAsync(roleId);

        //    if (role == null)
        //    {
        //        ViewBag.ErrorMesseage = $"This id {roleId} can not be found";
        //    }

        //    var model = new List<UserRoleViewModel>();

        //    foreach(var user in userManager.Users)
        //    {
        //        var userRoleViewModel = new UserRoleViewModel
        //        {
        //            UserId = user.Id,
        //            UserName = user.UserName
        //        };
        //        if (await userManager.IsInRoleAsync(user, role.Name))
        //        {
        //            userRoleViewModel.IsSelected = true;
        //        }
        //        else
        //        {
        //            userRoleViewModel.IsSelected = false;
        //        }
        //        model.Add(userRoleViewModel);
        //    }
        //    return View(model);
        //}
    }
}
