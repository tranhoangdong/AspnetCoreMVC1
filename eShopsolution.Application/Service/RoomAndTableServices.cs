using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
{
    public  class RoomAndTableServices : IRoomAndTableServices
    {
        private readonly EShopDbContext _eShopDbContext;

        public RoomAndTableServices(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }
        public List<RoomAndTableDTO> GetAllRoomAndTable()
        {
            var roomAndTable = _eShopDbContext.RoomAndTables.Select(r => new RoomAndTableDTO
            {
                Id = r.Id,
                Name = r.Name,
                Area = r.Area,
                Note = r.Note,
                OrdinalNumber = r.OrdinalNumber,
                Quantity = r.Quantity,
                StatusId = r.StatusId,
                StatusName = r.Status.Name
            }).ToList();
            return roomAndTable;
        }
        public async Task<RoomAndTableDTO> AddRoomAndTableAsync(RoomAndTableDTO roomandtableDto)
        {
            var roomandtable = new RoomAndTable
            {
                Name = roomandtableDto.Name,
                Area = roomandtableDto.Area,
                Note = roomandtableDto.Note,
                OrdinalNumber = roomandtableDto.OrdinalNumber,
                Quantity = roomandtableDto.Quantity,
               StatusId = roomandtableDto.StatusId,
            };
            _eShopDbContext.RoomAndTables.Add(roomandtable);
            await _eShopDbContext.SaveChangesAsync();
            return roomandtableDto;
        }
        public RoomAndTable GetNameTable(int ban)
        {
            return _eShopDbContext.RoomAndTables.FirstOrDefault(r => r.Id == ban);
        }



    }
}
