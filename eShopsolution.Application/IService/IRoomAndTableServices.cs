using eShopSolution.Application.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface IRoomAndTableServices
    {
        List<RoomAndTableDTO> GetAllRoomAndTable();
        Task<RoomAndTableDTO> AddRoomAndTableAsync(RoomAndTableDTO roomandtableDto);
    }
}
