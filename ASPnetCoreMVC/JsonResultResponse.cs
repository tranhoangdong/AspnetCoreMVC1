using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web
{
    public class JsonResultResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public int categoryId { get;set }
    }
}
