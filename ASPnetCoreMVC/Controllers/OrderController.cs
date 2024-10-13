﻿using eShopSolution.Application.Dtos;
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
        public async Task<IActionResult> SaveOrder(int ban)
        {
            var cartItems = GetCartItems();
            var roomAndTable = _roomAndTableServices.GetNameTable(ban);
            if (roomAndTable == null)
            {
                return Json(new { success = false, message = "Bàn không tồn tại!" });
            }

            var orderDetails = new List<OrderDetailDTO>();

            foreach (var orderDetail in cartItems)
            {
                var orderDetailDTO = new OrderDetailDTO
                {
                    Name = orderDetail.product.Name,
                    Price = orderDetail.product.Price,
                    TableName = roomAndTable.Name,
                    Time = DateTime.Now,
                    Quantity = orderDetail.quantity,
                    Tongtien = orderDetail.quantity * orderDetail.product.Price
                };

                orderDetails.Add(orderDetailDTO);
            }

            await _orderDetailService.AddOrderDetailAsync(orderDetails);

            return Json(new { success = true, message = "Đơn hàng đã được lưu thành công!" });
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

            var roomAndTableViewModel = new RoomAndTableViewModel
            {
                Id = roomAndTable.Id,
                Name = roomAndTable.Name,
            };

            decimal totalAmount = 0;
            foreach (var item in cartItems)
            {
                totalAmount += item.quantity * item.product.Price;
            }

            var checkoutViewModel = new CheckoutViewModel
            {
                RoomAndTable = roomAndTableViewModel,
                OrderTime = DateTime.Now,
                CartItems = cartItems,
                TotalAmount = totalAmount
            };

            return View(checkoutViewModel);
        }


    }
}
