using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiMovie.Controllers
{
    [Authorize(Roles = "مدیر عضویت")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return NotFound("نام نقش مورد نظر تنظیم نگردیده است.");

        //    await _roleManager.CreateAsync(new IdentityRole(name));
        //    return RedirectToAction(nameof(Index));
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return NotFound("نام نقش مورد نظر تنظیم نگردیده است.");

        //    var role = await _roleManager.FindByNameAsync(name);
        //    if (role == null)
        //        return NotFound(" نقش مورد نظر تنظیم یافت نشد.");

        //    await _roleManager.DeleteAsync(role);
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string name, string newName)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        return NotFound("نام نقش مورد نظر تنظیم نگردیده است.");

        //    var role = await _roleManager.FindByNameAsync(name);
        //    if (role == null)
        //        return NotFound(" نقش مورد نظر تنظیم یافت نشد.");

        //    role.Name = newName;
        //    await _roleManager.UpdateAsync(role);
        //    return RedirectToAction(nameof(Index));
        //}


    }
}