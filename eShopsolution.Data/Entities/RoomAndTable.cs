using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public  class RoomAndTable
    {
        public int Id {  get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }
        public string Note {  get; set; }
        public int OrdinalNumber { get; set; }
        public Status Status { get; set; }
    }
}
