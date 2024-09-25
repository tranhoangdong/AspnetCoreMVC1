﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<ImageDTO> Images { get; set; }
        public int CategoryId { get; set; }
    }
   
  
}
