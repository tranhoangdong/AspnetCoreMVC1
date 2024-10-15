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
        public void AddOrder(List<OrderDTO> orderDTOs)
        {
            try
            {
                var orders = new List<Order>();
                foreach (var OrderDTO in orderDTOs)
                {
                    var order = new Order
                    {
                        RoomAndTableId = OrderDTO.RoomAndTableId,
                        OrderTime = OrderDTO.OrderTime,
                        TotalAmount = OrderDTO.TotalAmount,
                    };

                    orders.Add(order);
                    _eShopDbContext.Orders.Add(order);
                }

                _eShopDbContext.SaveChanges();
                return ;
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
    }
}
