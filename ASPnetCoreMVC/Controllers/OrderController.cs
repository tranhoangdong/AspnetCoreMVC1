using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;
using eShopSolution.Web.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

using eShopSolution.Application.Common;

namespace eShopSolution.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomAndTableServices _roomAndTableServices;
        private readonly IOrderDetailService  _orderDetailService;



        public OrderController(IProductService productService, ICategoryService categoryService, IRoomAndTableServices roomAndTableServices, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roomAndTableServices = roomAndTableServices;
            _orderDetailService = orderDetailService;


        }
        public IActionResult LoadProductTable(int? categoryId)
        {
            var getAllProductsDTO = new ProductsRequestDto
            {
                CategoryId = categoryId
            };
            var resultDTO = _productService.GetAllProducts(getAllProductsDTO);


            var orderViewModels = resultDTO.PagedProducts.Select(p => new OrderViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.CategoryName
            }).ToList();

            return PartialView("_ProductTableOderPartial", orderViewModels);
        }

        public IActionResult Index(int? categoryId, int ban)
        {
            var categories = _categoryService.GetAllCategories(true).Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var roomAndTable = _roomAndTableServices.GetNameTable(ban);
            var roomAndTableViewModel = new RoomAndTableViewModel
            {
                Id = ban,
                Name = roomAndTable,
            };
            var allProductViewModel = new AllProductViewModel
            {
                Categories = categories,
                RoomAndTable = roomAndTableViewModel,
            };
            return View(allProductViewModel);
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
        [HttpPost]
        public IActionResult SaveOrder(int ban)
        {
            var cartItems = GetCartItems();
            var roomAndTable = _roomAndTableServices.GetNameTable(ban);
            if (roomAndTable == null)
            {
                return Json(new { success = false, message = "Bàn không tồn tại!" });
            }

            var orderResponseDto = new OrderResponseDto
            {
                RoomAndTableId = ban,
                OrderTime = DateTime.Now,
                OrderDetailDTOs = cartItems.Select(item => new OrderDetailDTO
                {
                    ProductId = item.product.Id,
                    Quantity = item.quantity,
                    Price = item.product.Price,
                }).ToList()

            };
            _orderDetailService.AddOrder(orderResponseDto);
            return Json(new JsonResultResponse
            { success = true,
              message = "Đơn hàng đã được lưu thành công!",
             });
        }


        [HttpGet]
        public IActionResult OrderDetails(int ban)
        {
            var cartItems = GetCartItems();
            var roomAndTable = _roomAndTableServices.GetNameTable(ban);
            if (roomAndTable == null)
            {
                return NotFound(); 
            }
            decimal totalAmount = 0;
            decimal thanhTien = 0;
            foreach (var item in cartItems)
            {
                thanhTien = item.quantity * item.product.Price;
                totalAmount += thanhTien;
                item.ThanhTien = thanhTien;
            }
            var checkoutViewModel = new CheckoutViewModel
            {
                BanId = ban,
                banName = roomAndTable,
                OrderTime = DateTime.Now,
                CartItems = cartItems,
                TotalAmount = totalAmount
            };

            return View(checkoutViewModel);
        }
        [HttpPost]
        public IActionResult AddToFavorites(int productId)
        {
            var favorites = HttpContext.Session.GetString("Favorites");
            var favoriteList = string.IsNullOrEmpty(favorites)
                ? new List<int>()
                : JsonConvert.DeserializeObject<List<int>>(favorites);

            if (!favoriteList.Contains(productId))
            {
                favoriteList.Add(productId);
                HttpContext.Session.SetString("Favorites", JsonConvert.SerializeObject(favoriteList));
                return Json(new JsonResultResponse
                {
                    success = true,
                    message = "Sản phẩm đã được thêm vào danh sách yêu thích!"
                });
            }
            else
            {
                return Json(new JsonResultResponse
                {
                    success = false,
                    message = "Sản phẩm đã có trong danh sách yêu thích!"
                });
            }
        }

    }
}
