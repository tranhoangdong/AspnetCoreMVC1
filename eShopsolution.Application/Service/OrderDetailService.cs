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

        public List<OrderResponseDto> GetAllOrders(OrderRequestDto orderRequestDto)
        {
            var orders = _eShopDbContext.Orders.AsQueryable();
            if (orderRequestDto.BanId > 0)
            {
                orders = orders.Where(o => o.RoomAndTableId == orderRequestDto.BanId);
            }
            if (orderRequestDto.OrderId > 0)
            {
                orders = orders.Where(o => o.Id == orderRequestDto.OrderId);
            }
            if (!string.IsNullOrEmpty(orderRequestDto.OrderStatus))
            {
                bool isPaid = orderRequestDto.OrderStatus == "paid";
                orders = orders.Where(o => o.IsPaid == isPaid);
            }
            if (orderRequestDto.StartDate.HasValue)
            {
                orders = orders.Where(o => o.OrderTime >= orderRequestDto.StartDate.Value);
            }
            if (orderRequestDto.EndDate.HasValue)
            {
                orders = orders.Where(o => o.OrderTime < orderRequestDto.EndDate.Value.AddDays(1));
            }

            return orders.Select(o => new OrderResponseDto
            {
                Id = o.Id,
                RoomAndTableId = o.RoomAndTableId,
                OrderTime = o.OrderTime,
                TotalAmount = o.TotalAmount,
                IsPaid = o.IsPaid
            }).ToList();
        }
        public List<OrderDetailsDTO> OrderDetails(int orderId)
        {
            var orderDetails = _eShopDbContext.OrderDetails.Where(o => o.OrderId == orderId).Select(o => new OrderDetailsDTO
            {
                Id = o.Id,
                Price = o.Price,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                Total = o.Total
            }).ToList();
            return orderDetails;
        }

        public void PayOrder(int id)
        {
            var order = _eShopDbContext.Orders.Find(id);
            if (order != null && !order.IsPaid)
            {
                order.IsPaid = true; 
                _eShopDbContext.SaveChanges();
            }
        }
        public int AddOrder(OrderResponseDto orderDTOs)
        {
            try
            {
                var totalAmount = orderDTOs.OrderDetailDTOs.Sum(odt => odt.Quantity * odt.Price);
                var order = new Order
                {
                    RoomAndTableId = orderDTOs.RoomAndTableId,
                    OrderTime = orderDTOs.OrderTime,
                    TotalAmount = totalAmount,
                    OrderDetails = orderDTOs.OrderDetailDTOs.Select(odt => new OrderDetail
                    {
                        OrderId = odt.OrderId,
                        ProductId = odt.ProductId,
                        Quantity = odt.Quantity,
                        Price = odt.Price,
                        Total = odt.Quantity * odt.Price
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
        public List<OrderDetailsDTO> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = _eShopDbContext.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new OrderDetailsDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    Price = od.Price,
                    Total = od.Total
                })
                .ToList();

            return orderDetails;
        }


    }
}
