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
            //var list = from p in _context.Products
            //           select p;



            //1-Linq Extension Methods (Filter Records)
            //var list = _context
            //    .Products
            //    .Where(p => p.NumberInStock > 600 && p.IsExists == true)
            //    .ToList();

            //1-Linq Query (Filter Records)
            //var list = from p in _context.Products
            //           where p.NumberInStock > 600 && p.IsExists==true
            //           select p;


            //2-Linq Extension Methods (Filter Columns)
            //2-1- Single Column
            //var list = _context
            //    .Products
            //    .Select(p => p.Title)
            //    .ToList();

            //2-2- Multiple Columns
            //var list = _context
            //    .Products
            //    .Select(p => new { p.Id , p.Title , p.Price })
            //    .ToList();

            //2-Linq Query (Filter Columns)
            //2-1- Single Column
            //var list = from p in _context.Products
            //           select p.Title;

            //2-2- Multiple Columns
            //var list = from p in _context.Products
            //           select new { p.Id, p.Title, p.Price };



            //3-
            //var list = _context
            //    .Products
            //    .OrderByDescending(p => p.Price)
            //    .ThenBy(p=>p.Title)
            //    .Take(20)
            //    .ToList();

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
        public IActionResult Create(Product product)
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
        public IActionResult Edit(int id , Product product)
        {
            if (id != product.Id)
                return NotFound();

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

        public IEnumerable<Product> Search(string q)
        {
            var list = _context
                .Products
                .Where(p=>p.Title.Contains(q))
                .ToList();


            return list;
        }
    }
}