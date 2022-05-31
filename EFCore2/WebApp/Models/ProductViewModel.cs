using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Please enter CategoryId")]
        public int CategoryId { get; set; }
    }
}
