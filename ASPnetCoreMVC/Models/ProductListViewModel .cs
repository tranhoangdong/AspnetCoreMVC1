using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDetailViewModel> Products { get; set; }
        public int TotalProducts { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

    }
}
