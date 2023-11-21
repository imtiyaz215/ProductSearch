using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SearchProduct.Data;
using SearchProduct.Models;
using SearchProduct.Models.ViewModels;

namespace SearchProduct.Controllers
{
    public class ProductController : Controller
    {
       
        private readonly ProductDBContext _dbContext;
        public ProductController(ProductDBContext db)
        {
            _dbContext = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var products = _dbContext.Products;
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.Products= products;
            PopulateDropdowns();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(ProductViewModel PModel)
        {
            int searchcounter = 0;
            // search counter is used to check if user selects multiple search options then in 
            // in that case search criteria should be selected
            if(PModel != null)
            {
                if (!string.IsNullOrEmpty(PModel.ProductName))
                {
                    searchcounter++;
                }

                if (!string.IsNullOrEmpty(PModel.Size))
                {
                    if(PModel.Size.Equals("Select Size"))
                    {
                        PModel.Size = null;
                    }
                    else
                        searchcounter++;

                }
                if(PModel.Price is not null)
                {
                    searchcounter++;
                }


                if (DateTime.TryParse(PModel.MfgDate.ToString(), out DateTime selectedDate))
                {
                    PModel.MfgDate = DateTime.Parse(PModel.MfgDate.ToString());
                    searchcounter++;
                }


                if (!string.IsNullOrEmpty(PModel.Category))
                {
                    if (PModel.Category.Equals("Select Category"))
                    {
                        PModel.Category = null;
                    }
                    else
                        searchcounter++;
                }
                if (searchcounter > 1 && PModel.SearchCriteria.Equals("Search Criteria"))
                {
                    ViewBag.Error = "Multiple searches selected but search criteria not provided";
                    PopulateDropdowns();
                    return View(PModel);

                }
                try
                {
                    PopulateDropdowns();
                    SqlParameter ProdName = new SqlParameter("@prodName", PModel.ProductName ?? (object)DBNull.Value);
                    SqlParameter ProdSize = new SqlParameter("@prodSize", PModel.Size ?? (object)DBNull.Value);
                    SqlParameter ProdPrice = new SqlParameter("@prodPrice", PModel.Price ?? (object)DBNull.Value);
                    SqlParameter ProdDate = new SqlParameter("@prodDate", PModel.MfgDate ?? (object)DBNull.Value);
                    SqlParameter ProdCategory = new SqlParameter("@prodCategory", PModel.Category ?? (object)DBNull.Value);
                    SqlParameter SearchCond = new SqlParameter("@SearchCondition", PModel.SearchCriteria ?? (object)DBNull.Value);

                    var result = _dbContext.Products
                        .FromSqlRaw<Product>("searchproducts {0}, {1}, {2},{3},{4}, {5}",
                        ProdName, ProdSize, ProdPrice, ProdDate, ProdCategory, SearchCond).ToList();
                    PModel.Products = result;
                    return View(PModel);

                }
                catch (Exception)
                {

                    ViewBag.Error = "There was some issue while searcing. please contact administrator";
                    PopulateDropdowns();
                    return View(PModel);
                }
            }
            PopulateDropdowns();
            return View(PModel);
        }
        private void PopulateDropdowns()
        {
            ViewBag.ProductCatetories = ProductCatetory.GetProductCategories();
            ViewBag.ProductSizes = ProductSize.GetProductSizes();
            ViewBag.SearchCriteria = SearchCriteria.GetSearchCriteria();
        }

    }
}
