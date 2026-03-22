using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Models
{
    public class WishlistViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal ProductPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
