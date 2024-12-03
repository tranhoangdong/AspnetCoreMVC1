using Microsoft.AspNetCore.Identity;

using System;

namespace eShopSolution.Data.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product Product { get; set; }
        public int quantity { set; get; }
    }
}