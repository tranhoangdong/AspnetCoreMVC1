using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PromoteEmployeeDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
