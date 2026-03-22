using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public  class OrderResponseDto
    {
        public int Id { get; set; }
        public int RoomAndTableId { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderDetailDTO> OrderDetailDTOs { get; set; }
    }
}
