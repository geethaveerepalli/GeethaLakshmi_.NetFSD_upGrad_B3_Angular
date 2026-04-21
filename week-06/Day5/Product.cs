using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Product Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(15, MinimumLength = 5,
            ErrorMessage = "Product Name must be 5 to 15 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }
}
