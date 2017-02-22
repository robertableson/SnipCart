using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using snipcart;

namespace snipcart.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly InMemoryDB _context;
 
        public HomeController(InMemoryDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {            
            var prodList = from p in _context.Products select p;

            return View(prodList);
        }

        public IActionResult AddNew()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var prod = (from p in _context.Products where p.Id.Equals(id)  select p).FirstOrDefault();

            return View(prod);
        }

        public IActionResult Product(int id)
        {
            var prod = (from p in _context.Products where p.Id.Equals(id)  select p).FirstOrDefault();

            return View(prod);
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGetAttribute]
        public string CreateNewProduct(string title, string desc, double price, string image){
            var testProd = new snipcart.Models.Product
            {
                Title = title,
                Description = desc, 
                Price = price,
                Image = image
            };

            _context.Products.Add(testProd);
            _context.SaveChanges();

            return "done";
        }
        [HttpGetAttribute]
        public string EditProduct(int id, string title, string desc, double price, string image){
            var oldProd = (from p in _context.Products where p.Id.Equals(id)  select p).FirstOrDefault();

            oldProd.Title = title;
            oldProd.Description = desc;
            oldProd.Price = price;
            oldProd.Image = image;

            _context.SaveChanges();
          
            return "done";
        }
    }
}
