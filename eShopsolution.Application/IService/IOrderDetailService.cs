using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface IOrderDetailService
    {
        int AddOrder(OrderResponseDto orderDTOs);
        List<OrderResponseDto> GetAllOrders(OrderRequestDto getOrderDTO);
        void PayOrder(int id);
        List<OrderDetailsDTO> OrderDetails(int orderId);
        List<OrderDetailsDTO> GetOrderDetailsByOrderId(int orderId);
    }
}
