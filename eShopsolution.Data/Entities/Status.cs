using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public  class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomAndTable> RoomAndTables { get; set; }
    }
}
