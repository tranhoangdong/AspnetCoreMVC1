using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class GetOrderDTO
    {
        public int Idban { get; set; }
        public int IdOrder { get; set; }
        public string StatusOrder { get; set; }
        public DateTime? EndDate  { get; set;}
        public DateTime? StartDate { get; set; }

    }
}
