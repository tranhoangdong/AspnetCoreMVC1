using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface IOrderDetailService
    {
        int AddOrder(OrderDTO orderDTOs);
        List<OrderDTO> GetAllOrders();
        void PayOrder(int id);
    }
}
