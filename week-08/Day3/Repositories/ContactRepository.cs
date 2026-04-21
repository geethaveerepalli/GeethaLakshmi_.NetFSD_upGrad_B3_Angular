using WebApplication12.Models;

namespace WebApplication12.Repository
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int nextId = 1;

        public Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return Task.FromResult(contacts.AsEnumerable());
        }
        public Task<ContactInfo>GetByIdAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return Task.FromResult(contact);
        }
        public Task<ContactInfo>AddAsync(ContactInfo contact)
        {
            contact.ContactId = nextId++;
            contacts.Add(contact);
            return Task.FromResult(contact);
        }
        public Task<bool> UpdateAsync(int id, ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);
            if(existing == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                existing.FirstName = contact.FirstName;
                existing.LastName = contact.LastName;
                existing.EmailId = contact.EmailId;
                existing.MobileNo = contact.MobileNo;
                existing.Designation = contact.Designation;
                existing.CompanyId = contact.CompanyId;
                existing.DepartmentId = contact.DepartmentId;
                return Task.FromResult(true);
            }
        }
        public Task<bool>DeleteAsync(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            if(contact == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                contacts.Remove(contact);
                return Task.FromResult(true);
            }
        }
    }

}
