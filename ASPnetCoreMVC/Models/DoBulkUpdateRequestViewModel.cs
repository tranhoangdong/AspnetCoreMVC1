using System.Collections.Generic;

namespace eShopSolution.Web.Models
{
    public class DoBulkUpdateRequestViewModel
    {
        public string Ids { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
