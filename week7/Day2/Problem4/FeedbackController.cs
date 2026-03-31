using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

       
        [HttpPost("form")]
        public IActionResult Form(Feedback feedback)
        {
            if (feedback.Rating >= 4)
            {
                ViewData["Message"] = $"Thank You {feedback.Name} for your feedback!";
            }
            else
            {
                ViewData["Message"] = $"We will improve, {feedback.Name}. Thanks for your feedback!";
            }

            return View();
        }
    }
}