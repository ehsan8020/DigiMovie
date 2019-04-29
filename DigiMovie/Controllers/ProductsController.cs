using DigiMovie.Data;
using DigiMovie.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DigiMovie.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;
        public ProductsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile image, Product product)
        {
            //return NotFound();
            if (ModelState.IsValid)
            {

                //Step 1 ) Check Validation Of Image
                //doesn't exist file
                if (image == null || image.Length == 0)
                    throw new Exception("عکس انتخاب شده برای محصول صحیح نمی باشد.");

                //larger than 1MB
                if (image.Length > 1048576)
                    throw new Exception("عکس انتخاب شده برای محصول بزرگتر از 1 مگابایت می باشد.");
                //unexpected file format
                if (image.ContentType != "image/jpg" && image.ContentType != "image/jpeg" && image.ContentType != "image/png" && image.ContentType != "image/gif")
                    throw new Exception("عکس انتخاب شده برای محصول در قالب مجاز نمی باشد.");


                //Step 2 ) Generate Name & Path Of File
                var imageName = DateTime.Now.ToString("yyyyMMddhhmmssffff") + System.IO.Path.GetExtension(image.FileName);
                var imagePath = System.IO.Path.Combine("UserUploads/Products", imageName);
                var imageAbsolutePath = Path.Combine(_env.WebRootPath, imagePath);

                //Step 3) Store File In Database
                using (var fs = new FileStream(imageAbsolutePath, FileMode.Create))
                {
                    image.CopyTo(fs);
                }

                //Step 4 - Add Image To Model
                product.ImagePath = "/UserUploads/Products/" + imageName;

                //Step 5 - Add Record To Database
                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    TempData["ProductCreateStatus"] = true;
                }
                catch (Exception e)
                {
                    TempData["ProductCreateStatus"] = false;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile image, Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {

                if(image == null)
                {
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                        TempData["ProductEditStatus"] = true;
                    }
                    catch (Exception e)
                    {
                        TempData["ProductEditStatus"] = false;
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Step 1 ) Check Validation Of Image
                    //doesn't exist file
                    if (image == null || image.Length == 0)
                        throw new Exception("عکس انتخاب شده برای محصول صحیح نمی باشد.");

                    //larger than 1MB
                    if (image.Length > 1048576)
                        throw new Exception("عکس انتخاب شده برای محصول بزرگتر از 1 مگابایت می باشد.");
                    //unexpected file format
                    if (image.ContentType != "image/jpg" && image.ContentType != "image/jpeg" && image.ContentType != "image/png" && image.ContentType != "image/gif")
                        throw new Exception("عکس انتخاب شده برای محصول در قالب مجاز نمی باشد.");


                    //Step 2 ) Generate Name & Path Of File
                    var imageName = DateTime.Now.ToString("yyyyMMddhhmmssffff") + System.IO.Path.GetExtension(image.FileName);
                    var imagePath = System.IO.Path.Combine("UserUploads/Products", imageName);
                    var imageAbsolutePath = Path.Combine(_env.WebRootPath, imagePath);

                    //Step 3) Store File In Database
                    using (var fs = new FileStream(imageAbsolutePath, FileMode.Create))
                    {
                        image.CopyTo(fs);
                    }

                    //Step 4 - Delete Old Image
                    var imageToDeleteAbsolutePath = _env.WebRootPath + product.ImagePath;

                    if (System.IO.File.Exists(imageToDeleteAbsolutePath))
                        System.IO.File.Delete(imageToDeleteAbsolutePath);

                    //Step 5 - Add Image To Model
                    product.ImagePath = "/UserUploads/Products/" + imageName;

                    //Step 6 - Add Record To Database
                    try
                    {
                        _context.Update(product);
                        await _context.SaveChangesAsync();
                        TempData["ProductEditStatus"] = true;
                    }
                    catch (Exception e)
                    {
                        TempData["ProductEditStatus"] = false;
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDone(int id)
        {
            var product = await _context.Products.FindAsync(id);

            //Step 1 - Delete Image From File System
            var imageAbsolutePath = _env.WebRootPath + product.ImagePath;

            if (System.IO.File.Exists(imageAbsolutePath))
                System.IO.File.Delete(imageAbsolutePath);


            //Step 2 - Delete Record
            try
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
                TempData["ProductDeleteStatus"] = true;
            }
            catch (Exception e)
            {
                TempData["ProductDeleteStatus"] = false;
            }
            return RedirectToAction(nameof(Index));
        }
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