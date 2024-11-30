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
using System;
using eShopSolution.Application.Common;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult GetCartItemCount()
        {
            var cart = GetCartItems(); 
            var count = cart.Sum(item => item.quantity);
            return Json(new { count }); 
        }
        //public IActionResult Wishlist()
        //{
        //    var wishlistItems = GetWishlistItems();

        //    var viewModel = wishlistItems.Select(item => new WishlistViewModel
        //    {
        //        ProductId = item.ProductId,
        //        ProductName = item.Product.Name, 
        //        ProductPrice = item.Product.Price, 
        //        CreatedAt = item.CreatedAt
        //    }).ToList();

        //    return View(viewModel);
        //}

        private List<Wishlist> GetWishlistItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(Constants.CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<Wishlist>>(jsoncart);
            }
            return new List<Wishlist>();
        }

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(Constants.CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(Constants.CARTKEY);
        }

        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(Constants.CARTKEY, jsoncart);
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
            return Json(new JsonResultResponse 
            {
                success = true,
                message = "Đã thêm vào giỏ hàng" 
            });
        }
        [HttpPost]
        public IActionResult AddToWishlist(int productid)
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
            return Json(new JsonResultResponse
            {
                success = true,
                message = "Đã thêm vào giỏ hàng"
            });
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
                return Json(new JsonResultResponse
                {
                    success = true,
                    message = "Sản phẩm đã được xóa khỏi giỏ hàng."
                });
            }

            return Json(new JsonResultResponse
            {
                success = false,
                message = "Không tìm thấy sản phẩm trong giỏ hàng."
            });
        }


        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            var carts = GetCartItems();
            var cartitem = carts.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity = quantity;
            }
            SaveCartSession(carts);
            return Ok();
        }

        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        public IActionResult WishList()
        {
            return View(GetWishlistItems());
        }
        [HttpPost]
        public IActionResult ToggleFavorite(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var existingFavorite =  _eShopDbContext.Wishlists
                .FirstOrDefault(f => f.ProductId == productId && f.UserId == userId);

            if (existingFavorite != null)
            {
                _eShopDbContext.Wishlists.Remove(existingFavorite);
               _eShopDbContext.SaveChanges();
                return Json(new { success = true, isFavorite = false });
            }
            else
            {
                var favorite = new Wishlist
                {
                    ProductId = productId,
                    UserId = userId,
                    CreatedAt = DateTime.Now
                };
                _eShopDbContext.Wishlists.Add(favorite);
                _eShopDbContext.SaveChanges();
                return Json(new JsonResultResponse 
                { success = true, isFavorite = true });
            }
        }

        public IActionResult FavoriteProducts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var favoriteProducts = _eShopDbContext.Wishlists
                .Where(f => f.UserId == userId)
                .Select(f => new WishlistViewModel
                {
                    ProductId = f.ProductId,
                    ProductName = f.Product.Name,
                    ProductPrice = f.Product.Price,
                    CreatedAt = f.CreatedAt,
        })
                .ToList();

            return View(favoriteProducts);
        }
        [HttpPost]
        public IActionResult RemoveFavorite(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new JsonResultResponse { success = false, message = "Bạn cần đăng nhập để thực hiện thao tác này!" });
            }

            var favorite =  _eShopDbContext.Wishlists
                .FirstOrDefault(f => f.ProductId == productId && f.UserId == userId);

            if (favorite == null)
            {
                return Json(new JsonResultResponse { success = false, message = "Sản phẩm không tồn tại trong danh sách yêu thích!" });
            }

            _eShopDbContext.Wishlists.Remove(favorite);
             _eShopDbContext.SaveChanges();

            return Json(new JsonResultResponse { success = true, message = "Đã xóa sản phẩm khỏi danh sách yêu thích!" });
        }

    }
}