using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;

using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class CartviewModel
    {
        public int Quantity { set; get; }
        public Product Product { set; get; }
    }
}
