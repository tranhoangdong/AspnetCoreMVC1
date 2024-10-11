using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public  class OrderDetailDTO
    {
        public int Id { get; set; }        
        public int ProductId { get; set; } 
        public string Name { get; set; }    
        public int Quantity { get; set; }   
        public float Price { get; set; }
        public float Tongtien { get; set; }
    }
}
