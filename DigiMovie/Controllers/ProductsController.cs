using DigiMovie.Data;
using DigiMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigiMovie.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDone(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            try
            {
                _context.Remove(product);
                _context.SaveChanges();
                //Delete Successful
                TempData["ProductDeleteStatus"] = true;
            }
            catch (Exception e)
            {
                //Delete Failed
                TempData["ProductDeleteStatus"] = false;
            }


            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(product);
                    _context.SaveChanges();
                    //Create Successful
                    TempData["ProductCreateStatus"] = true;
                }
                catch (Exception e)
                {
                    //Create Failed
                    TempData["ProductCreateStatus"] = false;
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    _context.SaveChanges();
                    //Edit Successful
                    TempData["ProductEditStatus"] = true;
                }
                catch (Exception e)
                {
                    //Edit Failed
                    TempData["ProductEditStatus"] = false;
                }

                return RedirectToAction("Index");
            }
            return View(product);
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