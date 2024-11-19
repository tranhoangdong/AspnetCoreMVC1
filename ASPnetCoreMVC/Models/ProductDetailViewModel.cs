using System.ComponentModel.DataAnnotations;

namespace eShopSolution.Web.Models
{
    public class ProductDetailViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        public int CategoryId { get; set; }
        public int TotalProducts { get; set; }
        public int CurrentPage { get; set; }

    }
}
