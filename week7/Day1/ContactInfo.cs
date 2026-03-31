using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Range(6000000000, 9999999999, ErrorMessage = "Enter valid mobile number")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
    }
}
