using eShopSolution.Application.Dtos;

using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float TongTien { get; set; }

    }
}
