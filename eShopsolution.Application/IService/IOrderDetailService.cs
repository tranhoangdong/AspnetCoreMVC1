using eShopSolution.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDTO> AddOrderDetailAsync(OrderDetailDTO orderDetailDTO);
    }
}
