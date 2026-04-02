using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;


namespace WebApplication5.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentCourseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
            return View(students);
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.Include(c => c.Students).ToList();
            return View(courses);
        }
    }
}
