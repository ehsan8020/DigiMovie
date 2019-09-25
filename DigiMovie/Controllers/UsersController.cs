using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiMovie.Areas.Identity.Data;
using DigiMovie.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiMovie.Controllers
{
    [Authorize(Roles = "مدیر عضویت")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileManager _ifileManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, IFileManager ifileManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _ifileManager = ifileManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound(" کاربری یافت نشد.");

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(" کاربر مورد نظر تنظیم یافت نشد.");

            //Delete User
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                //Delete User's Profile Image
                if (!user.ProfileImagePath.EndsWith("default.png"))
                    _ifileManager.DeleteFile(user.ProfileImagePath);

                //TODO: Delete Any Related Records in DB (if exists)

                //Check if current user is deleted user then signout him/her
                if (User.Identity.Name == user.UserName)
                    await _signInManager.SignOutAsync();
            }
            else
            {
                throw new InvalidOperationException($"خطای غیر منتظره در هنگام حذف کاربر با شناسه  '{user.Id}'.");
            }
            return RedirectToAction(nameof(Index));
        }

        public IEnumerable<ApplicationUser> Search(string q)
        {
            return _userManager
                .Users
                .Where(u => u.FirstName.Contains(q) || u.LastName.Contains(q) || u.UserName.Contains(q))
                .Take(10)//Maximun records goes here
                .ToList();
        }
    }
}