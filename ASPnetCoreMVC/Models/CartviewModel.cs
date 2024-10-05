using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;

using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class CartviewModel
    {
        public int quantity { set; get; }
        public Product product { set; get; }
    }
}
