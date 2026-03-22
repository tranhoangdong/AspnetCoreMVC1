using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int OrderId { get; set; }
        public int RoomAndTableID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
