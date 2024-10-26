namespace eShopSolution.Web.Models
{
    public class OrderViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int TotalProducts { get; set; }
        public int CurrentPage { get; set; }

    }
}
