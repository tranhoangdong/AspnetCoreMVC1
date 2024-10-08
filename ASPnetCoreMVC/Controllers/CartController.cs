using eShopSolution.Application.IService;
using Microsoft.AspNetCore.Mvc;
using eShopSolution.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Dtos;
using eShopSolution.Application.Service;
using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using eShopsolution.Data.EF;

namespace eShopSolution.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly EShopDbContext _eShopDbContext;


        public CartController(IProductService productService, ICategoryService categoryService, EShopDbContext eShopDbContext)
        {
            _productService = productService;
            _categoryService = categoryService;
            _eShopDbContext = eShopDbContext;
        }
        public const string CARTKEY = "cart";

        [HttpGet]
        public IActionResult GetCartItemCount()
        {
            var cart = GetCartItems(); 
            var count = cart.Sum(item => item.quantity);
            return Json(new { count }); 
        }

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        [HttpPost]
        public IActionResult AddToCart(int productid)
        {
            var product = _eShopDbContext.Products
                .Where(p => p.Id == productid)
                .FirstOrDefault();
            if (product == null)
                return NotFound("Không có sản phẩm");

            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            SaveCartSession(cart);
            return Json(new { success = true, message = "Đã thêm vào giỏ hàng" });
        }
        [HttpPost]
        public IActionResult RemoveCart(int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
                SaveCartSession(cart);
                return Json(new { success = true, message = "Sản phẩm đã được xóa khỏi giỏ hàng." });
            }

            return Json(new { success = false, message = "Không tìm thấy sản phẩm trong giỏ hàng." });
        }


        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            return Ok();
        }

        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

    }
}