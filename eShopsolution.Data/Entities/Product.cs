using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShopSolution.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Image> Images { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}