﻿using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;
using eShopSolution.Web.Models;

using Microsoft.AspNetCore.Mvc;

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


        public OrderController(IProductService productService, ICategoryService categoryService, IRoomAndTableServices roomAndTableServices)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roomAndTableServices = roomAndTableServices;

        }

        public IActionResult LoadProductTable(int? categoryId)
        {
            var products = _productService.GetAllProducts(categoryId);
            var orderViewModels = products.Select(p => new OrderViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = p.Category?.Name
            }).ToList();
            return PartialView("_ProductTableOderPartial", orderViewModels);
        }

        public IActionResult Index(int? categoryId, int Ban)
        {
            var categories = _categoryService.GetAllCategory(true).Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            var roomAndTable = _roomAndTableServices.GetAllRoomAndTable().FirstOrDefault(r => r.Id == Ban);
            var roomAndTableViewModel = new RoomAndTableViewModel
            {
                Id = roomAndTable.Id,
                Name = roomAndTable.Name,

            };
            var allProductViewModel = new AllProductViewModel
            {
                Categories = categories,
                RoomAndTable = roomAndTableViewModel

            };
            return View(allProductViewModel);
        }

      
    }
}
