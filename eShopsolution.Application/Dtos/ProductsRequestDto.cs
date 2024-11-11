using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class ProductsRequestDto : PagingDto
    {
        public int? CategoryId { get; set; }
        public string PriceFilter { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Name { get; set; }
        public int TotalProducts { get; set; } 
       
    }

}
