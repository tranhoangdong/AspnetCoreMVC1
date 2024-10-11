using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

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
        public async Task<OrderDetailDTO> AddOrderDetailAsync(OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = new OrderDetail
            {
               Name = orderDetailDTO.Name,
               Price = orderDetailDTO.Price,
               Quantity = orderDetailDTO.Quantity,
               Tongtien = orderDetailDTO.Tongtien   
            };
            _eShopDbContext.OrderDetails.Add(orderDetail);
            await _eShopDbContext.SaveChangesAsync();
            return orderDetailDTO;
        }

    }
}
