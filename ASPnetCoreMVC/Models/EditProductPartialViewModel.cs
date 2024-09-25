using eShopSolution.Application.Dtos;

using System.Collections.Generic;

namespace ASPnetCoreMVC.Models
{
    public class EditProductPartialViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public ProductDetailViewModel Product { get; set; }

    }
}
