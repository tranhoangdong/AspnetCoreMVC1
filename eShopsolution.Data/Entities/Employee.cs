using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public bool? IsActive { get; set; }   
        public DateTime? CreatedAt { get; set; } 
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Employee")]
        public ApplicationUser User { get; set; }
    }
}
