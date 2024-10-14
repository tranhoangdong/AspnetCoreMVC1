﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tongtien { get; set; }

    }
}
