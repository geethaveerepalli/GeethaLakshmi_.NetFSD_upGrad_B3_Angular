using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("product")]
    public class ProductEntryController : Controller
    {
        
        private static List<Product> productList = new List<Product>();

       
        [HttpGet("entry")]
        public IActionResult Entry()
        {
            ViewBag.Products = productList;
            return View();
        }

        
        [HttpPost("entry")]
        public IActionResult Entry(Product product)
        {
            
            productList.Add(product);

           
            ViewBag.Products = productList;

            return View();
        }
    }
}