using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class GetAllProductsDTO
    {
        public int? categoryId { get; set; }
        public string priceFilter { get; set; }
        public string sortColumn { get; set; }
        public string sortOrder { get; set; }
        public string name { get; set; }
    }

}
