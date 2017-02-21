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
        private readonly ApiContext _context;
 
        public HomeController(ApiContext context)
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
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Product(int id)
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGetAttribute]
        public string CreateNewProduct(string name){
            var testProd = new snipcart.Models.Product
            {
                Id = 3, 
                Title = "test",
                Description = "Best burger in town.", 
                Price = 12.99,
                Image = "http://proprofs-cdn.s3.amazonaws.com/images/FC/user_images/1878936/3960366298.jpg"
            };

            _context.Products.Add(testProd);
            _context.SaveChanges();

            return "done";
        }
    }
}
