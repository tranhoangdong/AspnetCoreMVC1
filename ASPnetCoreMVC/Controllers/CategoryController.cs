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
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomAndTableServices _roomAndTableServices;
        private readonly IOrderDetailService  _orderDetailService;



        public CategoryController(IProductService productService, ICategoryService categoryService, IRoomAndTableServices roomAndTableServices, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roomAndTableServices = roomAndTableServices;
            _orderDetailService = orderDetailService;


        }
        public IActionResult ListCategories()
        {
            var categoryDTOs = _categoryService.GetAllCategories();

            var categoryViewModels = categoryDTOs.Select(dto => new CategoryViewModel
            {
                Id = dto.Id,
                Name = dto.Name
            }).ToList();

            return View(categoryViewModels);
        }



    }
}
