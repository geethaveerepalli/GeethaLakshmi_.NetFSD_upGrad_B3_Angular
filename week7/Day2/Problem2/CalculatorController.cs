using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("Calculator")]
    public class CalculatorController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            ViewData["Result"] = result;

            return View("Index"); 
        }
    }
}