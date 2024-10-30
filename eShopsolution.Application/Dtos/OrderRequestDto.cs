using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class OrderRequestDto
    {
        public int BanId { get; set; }
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? EndDate  { get; set;}
        public DateTime? StartDate { get; set; }

    }
}
