using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

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
            }).ToList();
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
        public void AddOrderDetail(List<OrderDetailDTO> orderDetailDTOs)
        {
            try
            {
                var orderDetails = new List<OrderDetail>();
                foreach (var orderDetailDTO in orderDetailDTOs)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = orderDetailDTO.OrderId,
                        ProductId = orderDetailDTO.ProductId,
                        Quantity = orderDetailDTO.Quantity,
                        Price = orderDetailDTO.Price,
                        Total = orderDetailDTO.Total
                    };

                    orderDetails.Add(orderDetail);
                    _eShopDbContext.OrderDetails.Add(orderDetail);
                }

                _eShopDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public OrderDTO GetOrderById(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order == null) return null;

            return new OrderDTO
            {
                Id = order.Id,
                RoomAndTableId = order.RoomAndTableId,
                OrderTime = order.OrderTime,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDTO
                {
                    ProductId = od.ProductId,
                    ProductName = od.Product.Name,
                    Quantity = od.Quantity,
                    Price = od.Price,
                    Total = od.Total
                }).ToList()
            };
        }
    }
}
