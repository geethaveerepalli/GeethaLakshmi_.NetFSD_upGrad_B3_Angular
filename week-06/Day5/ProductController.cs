using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
        new Product { Id = 1, Name = "Laptop", Price = 50000 },
        new Product { Id = 2, Name = "Mobile", Price = 20000 },
        new Product { Id = 3, Name = "Tablet", Price = 15000 }
        };
        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
             if (ModelState.IsValid)   
            {
                products.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
            }

            return RedirectToAction("Index");
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}
