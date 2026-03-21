using eShopSolution.Application.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public  interface IUserManagementService
    {
        GetAllUserResultDTO GetAllUser();
        Task<ServiceResult> AddEmployee(PromoteEmployeeDTO promoteEmployeeDTO);
        Task<UserDTO> GetUserInfo(string UserId);
    }
}
