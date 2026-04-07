using ContactApp.Repositories;
using WebApplication7.Models;

namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ContactInfo> GetContacts()
        {
            return _repo.GetAll();
        }

        public ContactInfo GetContact(int id)
        {
            return _repo.GetById(id);
        }


        public void Create(ContactInfo contact)
        {
            _repo.Add(contact);
        }

        public void Update(ContactInfo contact)
        {
            _repo.Update(contact);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public IEnumerable<Company> GetCompanies()
        {
            return _repo.GetCompanies();
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _repo.GetDepartments();
        }
    }
}