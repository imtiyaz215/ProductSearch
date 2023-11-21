namespace SearchProduct.Models
{
    //public enum ProductCategory
    //{
    //    Standard = 0,
    //    Premium = 1,
    //    Economy = 2
    //}
    public static class ProductCatetory
    {
        public static List<string> GetProductCategories()
        {
            return new List<string> { "Select Category", "Standard", "Premium","Economy" };
        }
    }
}
