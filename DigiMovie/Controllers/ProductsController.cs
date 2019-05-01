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
            if (ModelState.IsValid)
            {
                try
                {
                    //Step 1- Check Validation Of Image
                    if (image == null || image.Length == 0)
                        throw new Exception("عکسی برای محصول انتخاب نشده است.");

                    if (image.Length > 1048576)
                        throw new Exception("عکس انتخاب شده برای محصول بزرگتر از 1 مگابایت می باشد.");

                    if (image.ContentType != "image/jpg" && image.ContentType != "image/jpeg" && image.ContentType != "image/png" && image.ContentType != "image/gif")
                        throw new Exception("عکس انتخاب شده برای محصول در قالب مجاز نمی باشد.");

                    //Step 2- Generate Name & Path Of File
                    var imageName = DateTime.Now.ToString("yyyyMMddhhmmssffff") + Path.GetExtension(image.FileName);
                    var imagePath = Path.Combine("UserUploads/Products", imageName);
                    var imageAbsolutePath = Path.Combine(_env.WebRootPath, imagePath);

                    //Step 3- Store File In File System
                    using (var fileStream = new FileStream(imageAbsolutePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                    }

                    //Step 4- Add Image Path To Model
                    product.ImagePath = "/UserUploads/Products/" + imageName;

                    //Step 5- Add Record To Database
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    TempData["ProductCreateStatus"] = "OK";
                }
                catch (Exception e)
                {
                    TempData["ProductCreateStatus"] = e.Message;
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
                if (image == null)
                {
                    //User doesn't want to change product image
                    try
                    {
                        _context.Update(product);
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
                    try
                    {
                        //Step 1- Check Validation Of Image
                        if (image.Length == 0)
                            throw new Exception("عکسی برای محصول انتخاب نشده است.");

                        if (image.Length > 1048576)
                            throw new Exception("عکس انتخاب شده برای محصول بزرگتر از 1 مگابایت می باشد.");

                        if (image.ContentType != "image/jpg" && image.ContentType != "image/jpeg" && image.ContentType != "image/png" && image.ContentType != "image/gif")
                            throw new Exception("عکس انتخاب شده برای محصول در قالب مجاز نمی باشد.");

                        //Step 2- Generate Name & Path Of File
                        var imageName = DateTime.Now.ToString("yyyyMMddhhmmssffff") + Path.GetExtension(image.FileName);
                        var imagePath = Path.Combine("UserUploads/Products", imageName);
                        var imageAbsolutePath = Path.Combine(_env.WebRootPath, imagePath);

                        //Step 3- Store File In File System
                        using (var fs = new FileStream(imageAbsolutePath, FileMode.Create))
                        {
                            image.CopyTo(fs);
                        }

                        //Step 4- Delete Old Image
                        var imageToDeleteAbsolutePath = _env.WebRootPath + product.ImagePath;
                        if (System.IO.File.Exists(imageToDeleteAbsolutePath))
                            System.IO.File.Delete(imageToDeleteAbsolutePath);

                        //Step 5- Add Image path to Model
                        product.ImagePath = "/UserUploads/Products/" + imageName;

                        //Step 6- Update Record To Database
                        _context.Update(product);
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

            try
            {
                //Step 1- Delete Image From File System
                var imageAbsolutePath = _env.WebRootPath + product.ImagePath;
                if (System.IO.File.Exists(imageAbsolutePath))
                    System.IO.File.Delete(imageAbsolutePath);

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

        public IEnumerable<Product> Search(string q)
        {
            return _context
                .Products
                .Where(p => p.Title.Contains(q))
                .Take(10)//Maximun records goes here
                .ToList();
        }

        //public IActionResult Temp()
        //{
        //    var r = new Random();
        //    int i =1;
        //    while (i <= 10)
        //    {
        //        var product = new Product();
        //        product.Title = "محصول نمونه " + i;
        //        product.IsExists = true;
        //        product.NumberInStock = Convert.ToInt16(r.Next(1, 1000)); ;
        //        product.Price = r.Next(1000, 9000) * 10000;
        //        product.Specification = "توضیحات مربوط به محصول نمونه " + i;
        //        product.ImagePath = "/UserUploads/Products/" + DateTime.Now.ToString("yyyyMMddhhmmssffff") + ".jpg";
        //        _context.Add(product);
        //        _context.SaveChanges();
        //        ++i;
        //    }
        //    return NotFound();
        //}
    }
}