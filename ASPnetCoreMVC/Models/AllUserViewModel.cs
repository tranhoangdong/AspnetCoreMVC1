using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Models
{
    public class AllUserViewModel
    {
       public List<UserViewModel> Userviewmodel { get; set; }
       public List<Role> Role { get; set; }
        public List<RoleUserViewModel> Roles { get; set; }
    }
}
