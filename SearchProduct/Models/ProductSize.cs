namespace SearchProduct.Models
{
    //public enum ProductSize
    //{
    //    S = 0,
    //    M = 1,
    //    L = 2,
    //    XL = 3,
    //    XXL = 4,
    //    XXXL = 5
    //}

    public static class ProductSize
    {
        public static List<string> GetProductSizes()
        {
            return new List<string> { "Select Size", "S", "M", "L", "XL", "XXL" };
        }
    }
}

