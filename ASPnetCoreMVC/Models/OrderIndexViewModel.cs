using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Models
{
    public class OrderIndexViewModel
    {
        public int Id { get; set; }
        public int RoomAndTableId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
