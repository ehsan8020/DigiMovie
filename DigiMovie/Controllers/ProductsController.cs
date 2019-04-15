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
        public IActionResult DeleteDone(int? id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(string Title, string IsExists, short NumberInStock, int Price, string Specification)
        {
            var product = new Product();
            product.Title = Title;
            product.NumberInStock = NumberInStock;

            if(IsExists == "E")
            {
                product.IsExists = true;
            }
            else
            {
                product.IsExists = false;
            }


            product.Price = Price;
            product.Specification = Specification;

             _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}