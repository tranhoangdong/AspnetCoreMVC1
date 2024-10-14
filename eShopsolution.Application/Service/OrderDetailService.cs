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
        public void AddOrderDetail(List<OrderDetailDTO> orderDetailDTOs)
        {
            try
            {
                var orderDetails = new List<OrderDetail>();
                foreach (var orderDetailDTO in orderDetailDTOs)
                {
                    var orderDetail = new OrderDetail
                    {
                        Name = orderDetailDTO.Name,
                        Price = orderDetailDTO.Price,
                        TableName = orderDetailDTO.TableName,
                        Time = orderDetailDTO.Time,
                        Quantity = orderDetailDTO.Quantity,
                        Tongtien = orderDetailDTO.Tongtien
                    };

                    orderDetails.Add(orderDetail);
                    _eShopDbContext.OrderDetails.Add(orderDetail);
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




    }
}
