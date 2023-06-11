using System.ComponentModel.DataAnnotations;

namespace TestTask.Web.Models
{
    public class OrderModel
    {
        [StringLength(40, ErrorMessage = "Maximun length of material is 40 characters")]
        [Required(ErrorMessage = "Material is a required field")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Quantity is a required field")]
        [RegularExpression(@"^(0|-?\d{1,8}(\.\d{0,3})?)$", ErrorMessage = "Valid Quality format is (8.3)")]
        public decimal? Quantity { get; set; }
    }
}
