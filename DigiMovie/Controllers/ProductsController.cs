using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiMovie.Data;
using DigiMovie.Models;
using Microsoft.AspNetCore.Mvc;

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
            var list = _context.Products.ToList();
            return View(list);
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
        public IActionResult DeleteDone(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            try
            {
                _context.Remove(product);
                _context.SaveChanges();
                //Delete Successful
                TempData["DeleteStatus"] = true;
            }
            catch (Exception e)
            {
                //Delete Failed
                TempData["DeleteStatus"] = false;
            }


            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
                //Create Successful
            }
            catch (Exception e)
            {
                //Create Failed
            }


            return RedirectToAction("Index");
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
        public IActionResult Edit(Product product)
        {
            try
            {
                _context.Update(product);
                _context.SaveChanges();
                //Edit Successful
            }
            catch (Exception e)
            {
                //Edit Failed
            }

            return RedirectToAction("Index");
        }

    }
}