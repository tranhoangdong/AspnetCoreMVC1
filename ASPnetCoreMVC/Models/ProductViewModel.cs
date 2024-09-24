﻿namespace ASPnetCoreMVC.Models
{
    public class ProductViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string CategoryName { get; set; }

    }
}
