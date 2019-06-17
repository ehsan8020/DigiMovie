using DigiMovie.Data;
using DigiMovie.Extensions;
using DigiMovie.Helpers;
using DigiMovie.Models;
using DigiMovie.Models.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileManager _ifileManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProductsController(ApplicationDbContext context, IFileManager ifileManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _ifileManager = ifileManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
                return View(await _context.Products.ToListAsync());
            else
                return View("ReadOnlyIndex",await _context.Products.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.Include(m => m.Category).SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }


        public IActionResult Create()
        {
            return View(new CreateEditVM()
            {
                Categories = _context.Categories.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Value = m.Id.ToString(),
                    Text = m.Title
                })
            });
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
                    var imagePath = Path.Combine("UserUploads/Products", imageName);

                    //Step 3- Store File In File System
                    _ifileManager.SaveFile(createEditVM.Image, imagePath);

                    //Step 4- Add Image Path To Model
                    createEditVM.Product.ImagePath = "/UserUploads/Products/" + imageName;

                    //Step 5- Add Record To Database
                    _context.Add(createEditVM.Product);
                    await _context.SaveChangesAsync();
                    TempData["ProductCreateStatus"] = "OK";
                }
                catch (Exception e)
                {
                    TempData["ProductCreateStatus"] = e.Message;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(createEditVM.Product);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return View(new CreateEditVM
            {
                Product = product,
                Categories = _context.Categories.Select(m => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Value = m.Id.ToString(),
                    Text = m.Title
                })
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, CreateEditVM createEditVM)
        {
            if (id != createEditVM.Product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (createEditVM.Image == null)
                {
                    //User doesn't want to change product image
                    try
                    {
                        _context.Update(createEditVM.Product);
                        await _context.SaveChangesAsync();
                        TempData["ProductEditStatus"] = "OK";
                    }
                    catch (Exception e)
                    {
                        TempData["ProductEditStatus"] = e.Message;
                    }
                    return RedirectToAction(nameof(Index));
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
                        var imagePath = Path.Combine("UserUploads/Products", imageName);

                        //Step 3- Store File In File System
                        _ifileManager.SaveFile(createEditVM.Image, imagePath);

                        //Step 4- Delete Old Image
                        _ifileManager.DeleteFile(createEditVM.Product.ImagePath);

                        //Step 5- Add Image path to Model
                        createEditVM.Product.ImagePath = "/UserUploads/Products/" + imageName;

                        //Step 6- Update Record To Database
                        _context.Update(createEditVM.Product);
                        await _context.SaveChangesAsync();
                        TempData["ProductEditStatus"] = "OK";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        TempData["ProductEditStatus"] = "عملیات مورد نظر به دلیل همزمانی با یک عملیات دیگر صورت نپذیرفت.";
                    }
                    catch (Exception e)
                    {
                        TempData["ProductEditStatus"] = e.Message;
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(createEditVM.Product);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.Include(m => m.Category).SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteDone(int id)
        {
            var product = await _context.Products.FindAsync(id);

            try
            {
                //Step 1- Delete Old Image
                _ifileManager.DeleteFile(product.ImagePath);

                //Step 2- Delete Record
                _context.Remove(product);
                await _context.SaveChangesAsync();
                TempData["ProductDeleteStatus"] = "OK";
            }
            catch (Exception e)
            {
                TempData["ProductDeleteStatus"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IEnumerable<Product> Search(string q)
        {
            return _context
                .Products
                .Where(p => p.Title.Contains(q))
                .Take(10)//Maximun records goes here
                .ToList();
        }
    }
}