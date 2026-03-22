using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class ImageDTO
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
    }
}
