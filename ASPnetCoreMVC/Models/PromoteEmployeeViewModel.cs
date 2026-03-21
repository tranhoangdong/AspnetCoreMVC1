using eShopSolution.Application.Dtos;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eShopSolution.Web.Models
{
    public class PromoteEmployeeViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }   // readonly

        [Display(Name = "Email")]
        public string Email { get; set; }       // readonly

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } // pre-filled, editable

        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be >= 0")]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [Display(Name = "Role")]
        public string Role { get; set; }  // "Employee" or "Admin"

        public string RoleId { get; set; }
    }
}
