using eShopSolution.Application.Dtos;

using System;
using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class OrderDetailViewModel
    {
        public string RoomAndTable { get; set; } 
        public DateTime OrderTime { get; set; }  
        public List<CartItemViewModel> CartItems { get; set; }

    }
}
