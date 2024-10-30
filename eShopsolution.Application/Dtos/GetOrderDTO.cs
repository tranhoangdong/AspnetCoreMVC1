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
    }
}
