using eShopSolution.Application.Dtos;

using System;
using System.Collections.Generic;

namespace eShopSolution.Web.Models
{

    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int RoomAndTableId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        List<OrderDetails> OrderDetails { get; set; }
    }
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
}
