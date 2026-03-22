using Microsoft.AspNetCore.Mvc;
using eShopSolution.Application.IService;

namespace eShopSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id?}")]
        public IActionResult Loadproduct(int? Id)
        {
            var products = _productService.GetProducts(Id);
            return Json(products);
        }
        [HttpGet("Load")]
        public IActionResult Loadmoreproduct([FromQuery] int? Id)
        {
            var products = _productService.GetProducts(Id);
            return Json(products);
        }
    }
}
