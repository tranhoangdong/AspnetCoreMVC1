using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Web.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public AdminUserController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            var resultUser = _userManagementService.GetAllUser();
            var userViewmodel = resultUser.User.Select(u => 
            new UserViewModel
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Role = u.Role
            }).ToList();

            return View(new AllUserViewModel { Userviewmodel = userViewmodel });
        }
        [HttpGet]
        public async Task<IActionResult> AddEmployee (string UserId)
        {
            var getuser = await _userManagementService.GetUserInfo(UserId);
            if (getuser == null)
                return NotFound("User không tồn tại");
            var getuserViewmodel = new PromoteEmployeeViewModel
            {
                UserId = getuser.Id,
                Email = getuser.Email,
                UserName = getuser.UserName,
                PhoneNumber = getuser.PhoneNumber,
                Roles = getuser.roledto.Select(r => new RoleUserViewModel
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                }).ToList()
            };
            return PartialView("_AddEmployeePartialView", getuserViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult>  AddEmployee ([FromBody] PromoteEmployeeViewModel promoteEmployee )
        {
            var promoteEmployeeDto = new PromoteEmployeeDTO
            {
                UserName = promoteEmployee.UserName,
                UserId = promoteEmployee.UserId,
                RoleId = promoteEmployee.RoleId,
                Email = promoteEmployee.Email,
                FullName = promoteEmployee.FullName,
                PhoneNumber = promoteEmployee.PhoneNumber,
                Position = promoteEmployee.Position,
                Salary = promoteEmployee.Salary
            };
            var result  = await _userManagementService.AddEmployee(promoteEmployeeDto);
            if (result.Success)
                return Json(new { success = true, message = result.Message });

            return Json(new { success = false, message = result.Message });

        }
      
    }
}
