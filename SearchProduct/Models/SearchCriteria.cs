namespace SearchProduct.Models
{

        //public enum SearchCriteria
        //{
        //    OR = 0,
        //    AND = 1
        //}
    public static class SearchCriteria
    {
        public static List<string> GetSearchCriteria()
        {
            return new List<string> { "Search Criteria","OR", "AND" };
        }
    }

}
