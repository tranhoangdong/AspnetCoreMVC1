using eShopSolution.Data.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class GetAllProductResultDTO : PagingDto
    {
        public int TotalProducts { get; set; }
        public List<ProductResultDTO> PagedProducts { get; set; }
    }
}
