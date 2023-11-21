using System.ComponentModel.DataAnnotations;

namespace SearchProduct.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required, MaxLength(50)]
        public string ProductName { get; set; }
        [Required, MaxLength(10)]
        public string Size { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public DateTime MfgDate { get; set; }
        [Required, MaxLength (50)]
        public string Category { get; set; }
    }
}
