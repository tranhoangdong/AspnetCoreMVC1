using eShopSolution.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface IOrderDetailService
    {
        void AddOrder(List<OrderDTO> orderDTOs);
        void AddOrderDetail(List<OrderDetailDTO> orderDetailDTOs);
    }
}
