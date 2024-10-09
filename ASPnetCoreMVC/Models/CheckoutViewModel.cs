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
        public RoomAndTableViewModel RoomAndTable { get; set; }

    }

}

