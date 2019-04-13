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
            #region TestCodes

            //var car = new Product();
            //car.Id = 1;
            //car.Title = "Benz";
            //car.Specification = "Best Vehicle In World";
            //car.NumberInStock = 2;
            //car.IsExists = true;

            //return View(car);



            //var p1 = new Product();
            //p1.Id = 1;
            //p1.Title = "Benz";
            //p1.Specification = "Best Vehicle In World";
            //p1.NumberInStock = 2;
            //p1.IsExists = true;

            //var p2 = new Product();
            //p2.Id = 2;
            //p2.Title = "BMW";
            //p2.Specification = "Most Beautiful Vehicle In World";
            //p2.NumberInStock = 1;
            //p2.IsExists = true;

            //var p3 = new Product();
            //p3.Id = 3;
            //p3.Title = "Pride";
            //p3.Specification = "Most Dangerous Vehicle In World";
            //p3.NumberInStock = 1000;
            //p3.IsExists = true;


            //var listOfProducts = new List<Product>();
            //listOfProducts.Add(p1);
            //listOfProducts.Add(p2);
            //listOfProducts.Add(p3);


            //return View(listOfProducts);

            #endregion
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

    }
}