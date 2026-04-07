using WebApplication7.Models;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<ContactInfo> GetAll();   
        ContactInfo GetById(int id);
        void Add(ContactInfo contact);
        void Update(ContactInfo contact);
        void Delete(int id);
        IEnumerable<Company> GetCompanies();
        IEnumerable<Department> GetDepartments();
    }
}