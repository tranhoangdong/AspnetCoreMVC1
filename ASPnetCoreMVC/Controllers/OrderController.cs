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
        public const string CARTKEY = "cart";
        public IActionResult LoadProductTable(int? categoryId)
        {
            var getAllProductsDTO = new GetAllProductsDTO
            {
                categoryId = categoryId
            };
            var products = _productService.GetAllProducts(getAllProductsDTO);
            var orderViewModels = products.Select(p => new OrderViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category?.Name
            }).ToList();
            return PartialView("_ProductTableOderPartial", orderViewModels);
        }

        public IActionResult Index(int? categoryId, int ban)
        {
            var categories = _categoryService.GetAllCategory(true).Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var roomAndTable = _roomAndTableServices.GetNameTable(ban);
            var roomAndTableViewModel = new RoomAndTableViewModel
            {
                Id = roomAndTable.Id,
                Name = roomAndTable.Name,
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
            string jsoncart = session.GetString(CARTKEY);
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

            var totalAmount = cartItems.Sum(item => item.quantity * item.product.Price);
            var orderDTO = new OrderDTO
            {
                RoomAndTableId = roomAndTable.Id,
                OrderTime = DateTime.Now,
                TotalAmount = totalAmount
            };
            var orderId = _orderDetailService.AddOrder(orderDTO);
            return Json(new JsonResultResponse
            { success = true,
              message = "Đơn hàng đã được lưu thành công!",
              orderId = orderId });
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
                BanId = roomAndTable.Id,
                banName = roomAndTable.Name,
                OrderTime = DateTime.Now,
                CartItems = cartItems,
                TotalAmount = totalAmount
            };

            return View(checkoutViewModel);
        }
        [HttpPost]
        public IActionResult SaveOrderDetails(int ban, int orderId)
        {
            var cartItems = GetCartItems(); 
            var orderDetails = new List<OrderDetailDTO>();

            foreach (var cartItem in cartItems)
            {
                var orderDetailDto = new OrderDetailDTO
                {
                    OrderId = orderId, 
                    ProductId = cartItem.product.Id,
                    Quantity = cartItem.quantity,
                    Price = cartItem.product.Price,
                    Total = cartItem.quantity * cartItem.product.Price
                };

                orderDetails.Add(orderDetailDto);
            }
            _orderDetailService.AddOrderDetail(orderDetails);

            return Json(new JsonResultResponse
            {
                success = true,
                message = "Chi tiết đơn hàng đã được lưu"
            });
        }


    }
}
