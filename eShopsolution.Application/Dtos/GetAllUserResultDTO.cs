using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class GetAllUserResultDTO
    {
        public List<UserDTO> User {get; set;}
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<RoleDTO> Roledto { get; set; }
    }

}
