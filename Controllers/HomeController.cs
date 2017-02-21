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
            //var product = _context.Products.FirstOrDefault();

            List<snipcart.DbModels.Product> prodList = new List<snipcart.DbModels.Product>(){
                new snipcart.DbModels.Product {
                    Id = 1, 
                    Title = "titre1",
                    Description = "desc1", 
                    Price = 97.99,
                    Image = "fkhjbfksjn.jpg"}
            };

            return View(prodList);
        }

        public IActionResult AddNew()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        
 
       /* public async Task<IActionResult> Get()
        { 
            var response = _context.Products.Select(u => new
            {
                title = u.Title,
                desc = u.Description,
                price = u.Price,
                image = u.Image
            });

            

            
 
            return Ok(response);
        }*/
    }
}
