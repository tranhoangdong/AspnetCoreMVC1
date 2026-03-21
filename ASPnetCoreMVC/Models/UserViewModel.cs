using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }    
        public string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
