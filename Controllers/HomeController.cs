using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using snipcart;

namespace snipcart.Controllers
{
    //[Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ApiContext _context;
 
        public HomeController(ApiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var prodList = _context.Products.FirstOrDefault();

            List<snipcart.Models.Product> prodList = new List<snipcart.Models.Product>(){
                new snipcart.Models.Product {
                    Id = 1, 
                    Title = "Jordans S2K Sr edition",
                    Description = "The Jordans S2K Sr edition is the best bang for your buck.", 
                    Price = 97.99,
                    Image = "http://simpleproductphotography.com/wp-content/uploads/2016/06/huf-converse-product-red-skidgrip-1.jpg"
                },
                new snipcart.Models.Product {
                    Id = 2, 
                    Title = "Lamborghini Huracan",
                    Description = "The Lamborghini Huracan is definitely the best supercar for the money.", 
                    Price = 278999.99,
                    Image = "http://1.bp.blogspot.com/-Gaj30dheGzE/VfGQL2uD0_I/AAAAAAAAWJ4/IOomh6RXDpY/w800/lambo-huracan-roadster-rendering-ts-4.jpg"
                }
            };

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

        
 
       /*public async Task<IActionResult> Get()
        { 
            var response = _context.Products.Select(u => new
            {
                id = u.Id,
                title = u.Title,
                desc = u.Description,
                price = u.Price,
                image = u.Image
            });

            

            
 
            return Ok(response);
        }*/
    }
}
