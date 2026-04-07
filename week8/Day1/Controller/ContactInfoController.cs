using ContactApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication7.Models;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var contacts = _service.GetContacts();
            return View(contacts);
        }

     
        public IActionResult Details(int id)
        {
            var contact = _service.GetContact(id);
            return View(contact);
        }

       
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_service.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_service.GetDepartments(), "DepartmentId", "DepartmentName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            _service.Create(contact); 
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var contact = _service.GetContact(id);

            ViewBag.Companies = new SelectList(_service.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_service.GetDepartments(), "DepartmentId", "DepartmentName");

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            _service.Update(contact);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

    }
}