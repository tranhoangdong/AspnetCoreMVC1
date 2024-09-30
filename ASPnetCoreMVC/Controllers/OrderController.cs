using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public OrderController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult LoadProductTable(string name, string priceFilter, string sortColumn, string sortOrder, int? categoryId)
        {
            var products = _productService.GetAllProducts(name, priceFilter, sortColumn, sortOrder, categoryId);
            var productViewModels = products.Select(p => new ProductDetailViewModel
            {
                ID = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category?.Name
            }).ToList();
            return PartialView("_ProductTableOderPartial", productViewModels);
        }

        public IActionResult Index(string name, string priceFilter, string sortColumn, string sortOrder, int? categoryId)
        {
            var categories = _categoryService.GetAllCategory().Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var allProductViewModel = new AllProductViewModel
            {
                Categories = categories,

            };

            return View(allProductViewModel);
        }

      
    }
}
