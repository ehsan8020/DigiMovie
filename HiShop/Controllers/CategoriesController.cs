using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HiShop.Areas.Identity.Data;
using HiShop.Data;
using HiShop.Extensions;
using HiShop.Helpers;
using HiShop.Models;
using HiShop.Models.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HiShop.Controllers
{
    [Authorize(Roles = "مدیر دسته بندی ها")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileManager _ifileManager;

        public CategoriesController(ApplicationDbContext context, IFileManager ifileManager)
        {
            _context = context;
            _ifileManager = ifileManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        public async Task<IActionResult> AdminIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditVM createEditVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Step 1- Check Validation Of Image
                    createEditVM.Image.Check(1048576, new string[] { "image/jpg", "image/jpeg", "image/png", "image/gif" });

                    //Step 2- Generate Name & Path Of File
                    var imageName = DateTime.Now.ToString("yyyyMMddhhmmssffff") + Path.GetExtension(createEditVM.Image.FileName);
                    var imagePath = Path.Combine("UserUploads/Categories", imageName);

                    //Step 3- Store File In File System
                    _ifileManager.SaveFile(createEditVM.Image, imagePath);

                    //Step 4- Add Image Path To Model
                    createEditVM.Category.ImagePath = "/UserUploads/Categories/" + imageName;

                    //Step 5- Add Record To Database
                    _context.Add(createEditVM.Category);
                    await _context.SaveChangesAsync();
                    TempData["CategoryCreateStatus"] = "OK";
                }
                catch (Exception e)
                {
                    TempData["CategoryCreateStatus"] = e.Message;
                }
                return RedirectToAction(nameof(AdminIndex));
            }
            return View(createEditVM.Category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return View(new CreateEditVM
            {
                Category = category
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateEditVM createEditVM)
        {
            if (id != createEditVM.Category.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (createEditVM.Image == null)
                {
                    //User doesn't want to change product image
                    try
                    {
                        _context.Update(createEditVM.Category);
                        await _context.SaveChangesAsync();
                        TempData["CategoryEditStatus"] = "OK";
                    }
                    catch (Exception e)
                    {
                        TempData["CategoryEditStatus"] = e.Message;
                    }
                    return RedirectToAction(nameof(AdminIndex));
                }
                else
                {
                    //User wants to change product image
                    try
                    {
                        //Step 1- Check Validation Of Image
                        createEditVM.Image.Check(1048576, new string[] { "image/jpg", "image/jpeg", "image/png", "image/gif" });

                        //Step 2- Generate Name & Path Of File
                        var imageName = DateTime.Now.ToString("yyyyMMddhhmmssffff") + Path.GetExtension(createEditVM.Image.FileName);
                        var imagePath = Path.Combine("UserUploads/Categories", imageName);

                        //Step 3- Store File In File System
                        _ifileManager.SaveFile(createEditVM.Image, imagePath);

                        //Step 4- Delete Old Image
                        _ifileManager.DeleteFile(createEditVM.Category.ImagePath);

                        //Step 5- Add Image path to Model
                        createEditVM.Category.ImagePath = "/UserUploads/Categories/" + imageName;

                        //Step 6- Update Record To Database
                        _context.Update(createEditVM.Category);
                        await _context.SaveChangesAsync();
                        TempData["CategoryEditStatus"] = "OK";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        TempData["CategoryEditStatus"] = "عملیات مورد نظر به دلیل همزمانی با یک عملیات دیگر صورت نپذیرفت.";
                    }
                    catch (Exception e)
                    {
                        TempData["CategoryEditStatus"] = e.Message;
                    }
                    return RedirectToAction(nameof(AdminIndex));
                }
            }
            return View(createEditVM.Category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDone(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            try
            {
                //Step 1- Delete Record
                _context.Remove(category);
                await _context.SaveChangesAsync();

                //Step 2- Delete Old Image
                _ifileManager.DeleteFile(category.ImagePath);
                TempData["CategoryDeleteStatus"] = "OK";
            }
            catch (Exception e)
            {
                TempData["CategoryDeleteStatus"] = e.Message;
            }
            return RedirectToAction(nameof(AdminIndex));
        }

        [AllowAnonymous]
        public IEnumerable<Category> Search(string q)
        {
            return _context
                .Categories
                .Where(m => m.Title.Contains(q))
                .Take(10)//Maximun records goes here
                .ToList();
        }

        [AllowAnonymous]
        public async Task<IActionResult> RelatingProducts(int? id, string cat)
        {
            if (id == null)
                return NotFound();

            ViewData["cat"] = cat;
            return View(await _context.Products.Where(m => m.CatId == id).ToListAsync());
        }
    }
}