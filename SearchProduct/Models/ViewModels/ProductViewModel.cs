using System.ComponentModel.DataAnnotations;

namespace SearchProduct.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string ProductName { get; set; } = null;
        public string Size { get; set; } = null;
        public float? Price { get; set; } = null;
        public DateTime? MfgDate { get; set; } = null;
        public string Category { get; set; } = null;
        public string SearchCriteria { get; set; } = null;
    }
}
