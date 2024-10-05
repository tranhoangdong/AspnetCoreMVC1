using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class CartItem
    {
        public int quantity { set; get; }
        public Product product { set; get; }
    }
}
