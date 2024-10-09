using eShopSolution.Application.Dtos;

using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class AllProductViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public ProductDetailViewModel Product { get; set; }
        public RoomAndTableViewModel RoomAndTable { get; set; }

    }
}
