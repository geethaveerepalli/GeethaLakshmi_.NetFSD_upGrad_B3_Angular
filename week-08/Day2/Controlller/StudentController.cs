using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication9.Models;
using WebApplication9.Repositories;

public class StudentController : Controller
{
    private readonly IStudentRepository _repo;

    public StudentController(IStudentRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var data = _repo.GetStudentsWithCourse();
        return View(data);
    }

 
    public IActionResult Courses()
    {
        var data = _repo.GetCoursesWithStudents();
        return View(data);
    }


    public IActionResult Create()
    {
        ViewBag.Courses = new SelectList(_repo.GetAllCourses(), "CourseId", "CourseName");
        return View();
    }


    [HttpPost]
    public IActionResult Create(Student student)
    {
        _repo.AddStudent(student);
        return RedirectToAction("Index");
    }
}