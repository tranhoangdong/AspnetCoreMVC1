using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;

using System;
using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class CheckoutViewModel
    {
            public List<CartItem> CartItems { get; set; }
            public DateTime OrderTime { get; set; }
            public decimal TotalAmount { get; set; } 
            public int BanId { get; set; }
            public string banName { get; set; }
    }

}

