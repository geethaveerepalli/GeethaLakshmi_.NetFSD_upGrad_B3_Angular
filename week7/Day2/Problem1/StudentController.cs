using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost("Register")]
        public IActionResult Register(string name, int age, string course)
        {
            TempData["Name"] = name;
            TempData["Age"] = age;
            TempData["Course"] = course;

            return RedirectToAction("Display");
        }

        
        [HttpGet("Display")]
        public IActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];

            return View();
        }
    }
}