using eShopSolution.Data.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class GetAllProductResuftDTO
    {
        public int TotalProducts { get; set; }
        public List<ProductResuftDTO> PagedProducts { get; set; }
    }
}
