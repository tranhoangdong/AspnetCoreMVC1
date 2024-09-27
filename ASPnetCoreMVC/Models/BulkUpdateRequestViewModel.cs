using System.Collections.Generic;

namespace ASPnetCoreMVC.Models
{
    public class BulkUpdateRequestViewModel
    {
        public List<string> ProductId { get; set; }
        public decimal NewPrice { get; set; }
        public int NewStock { get; set; }

    }
}
