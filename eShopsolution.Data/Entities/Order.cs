using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }  
        public int RoomAndTableId { get; set; }  
        public DateTime OrderTime { get; set; } 
        public decimal TotalAmount { get; set; }  
        public string Note { get; set; }
        public bool IsPaid { get; set; }
        public RoomAndTable RoomAndTable { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
