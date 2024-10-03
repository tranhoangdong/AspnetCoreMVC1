using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public  class RoomAndTableDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public string Note { get; set; }
        public string StatusName { get; set; }
        public int OrdinalNumber { get; set; }
    }
}
