using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
namespace WebApplication5.Models

{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }

        public string Designation { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        public Company Company { get; set; }
        public Department Department { get; set; }
    }
}
