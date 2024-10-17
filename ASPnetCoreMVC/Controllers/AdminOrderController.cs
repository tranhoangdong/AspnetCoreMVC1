using eShopSolution.Application.Dtos;
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
                IsPaid = o.IsPaid
            }).ToList();
            return View(orderViewModels);
        }
        [HttpPost]
        public IActionResult PayOrder(int id)
        {
            var order = _orderDetailService.GetOrderById(id);
            if (order != null && !order.IsPaid)  
            {
                order.IsPaid = true;
                var oderDto = new OrderDTO
                {
                    Id = order.Id,
                    IsPaid = order.IsPaid,
                };
                _orderDetailService.UpdateOrder(oderDto);
            }
          
            return RedirectToAction("Index");  
        }
    }
}
