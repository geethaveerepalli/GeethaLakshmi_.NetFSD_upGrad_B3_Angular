using System.ComponentModel.DataAnnotations;
namespace WebApplication12.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

    }
}
