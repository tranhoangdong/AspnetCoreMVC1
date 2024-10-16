using eShopSolution.Application.IService;
using eShopSolution.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;

        public AdminOrderController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            var orders = _orderDetailService.GetAllOrders();
            var orderViewModels = orders.Select(o => new OrderIndexViewModel
            {
                Id = o.Id,
                RoomAndTableId = o.RoomAndTableId,
                TotalAmount = o.TotalAmount,
                OrderTime = o.OrderTime,
            }).ToList();

            return View(orderViewModels);
        }
        public IActionResult Details(int id)
        {
            var order = _orderDetailService.GetOrderById(id);
            if (order == null) return NotFound();

            var orderDetailViewModel = new OrderDetailsViewModel
            {
                Id = order.Id,
                RoomAndTableId = order.RoomAndTableId,
                OrderTime = order.OrderTime,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                OrderDetails = order.OrderDetails.Select(od => new OrderItemViewModel
                {
                    Quantity = od.Quantity,
                    Price = od.Price,
                    Total = od.Total
                }).ToList()
            };
            return View(orderDetailViewModel);
        }
    }
}
