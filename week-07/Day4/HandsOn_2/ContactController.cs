using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication5.Models;
using WebApplication5.Repository;

namespace WebApplication5.Controllers
{
   
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;
        private readonly ContactDbContext _context;

        public ContactController(IContactRepository repo, ContactDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }

            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", contact.DepartmentId);

            return View(contact);
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();

            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", contact.DepartmentId);
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }
            ViewBag.Companies = new SelectList(_context.Companies, "CompanyId", "CompanyName", contact.CompanyId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", contact.DepartmentId);
            return View(contact);
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();
            return View(contact);
        }
    }
}