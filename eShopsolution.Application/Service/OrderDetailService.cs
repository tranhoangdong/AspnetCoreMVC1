using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly EShopDbContext _eShopDbContext;

        public OrderDetailService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public List<OrderDTO> GetAllOrders()
        {
            return _eShopDbContext.Orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                RoomAndTableId = o.RoomAndTableId,
                OrderTime = o.OrderTime,
                TotalAmount = o.TotalAmount,
                IsPaid = o.IsPaid
            }).ToList();
        }
        public OrderDTO GetOrderById(int id)
        {
            return _eShopDbContext.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    RoomAndTableId = o.RoomAndTableId,
                    OrderTime = o.OrderTime,
                    TotalAmount = o.TotalAmount,
                    IsPaid = o.IsPaid  
        })
                .FirstOrDefault();
        }
        public int AddOrder(OrderDTO orderDTOs)
        {
            try
            {
                var order = new Order
                {
                    RoomAndTableId = orderDTOs.RoomAndTableId,
                    OrderTime = orderDTOs.OrderTime,
                    TotalAmount = orderDTOs.TotalAmount,
                    OrderDetails = orderDTOs.OrderDetailDTOs.Select(odt => new OrderDetail
                    {
                        OrderId = odt.OrderId,
                        ProductId = odt.ProductId,
                        Quantity = odt.Quantity,
                        Price = odt.Price,
                        Total = odt.Total
                    }).ToList()
                };
                _eShopDbContext.Orders.Add(order);
                _eShopDbContext.SaveChanges();
                return order.Id; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var order = _eShopDbContext.Orders.Find(orderDTO.Id);
            if (order != null)
            {
                order.IsPaid = orderDTO.IsPaid;  
                _eShopDbContext.SaveChanges();  
            }
        }

       
    }
}
