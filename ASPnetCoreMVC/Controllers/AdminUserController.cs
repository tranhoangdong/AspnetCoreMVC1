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
                Role = u.Role,
            }).ToList();
            var roleUser = resultUser.Roledto.Select(ru => new RoleUserViewModel
            {
                RoleId = ru.RoleId,
                RoleName = ru.RoleName
            }).ToList();
            var alluserviewmodel = new AllUserViewModel
            {
                Userviewmodel = userViewmodel,
                Roles = roleUser
            };
            return View(alluserviewmodel);
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
        [HttpGet]
        public async Task<IActionResult> LoadUser( string userName, string roleId)
        {
            var userrequestDto = new UserRequestDTO
            {
                UserName = userName,
                RoleId = roleId
            };
            var user = await _userManagementService.LoadUser(userrequestDto);
            var userviewmodel =  user.Select(u => new UserViewModel
            {
                Role = u.Role,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserId = u.Id,
                UserName = u.UserName
            }).ToList();

            return PartialView("_LoadUserpartialView", userviewmodel);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(string UserId)
        {
            var userinfo = await _userManagementService.GetUserInfo(UserId);
            var promoUserViewmodel = new PromoteEmployeeViewModel
            {
                UserName = userinfo.UserName,
                Email = userinfo.Email,
                PhoneNumber = userinfo.PhoneNumber,
                Roles = userinfo.roledto.Select(u => new RoleUserViewModel
                {
                    RoleId = u.RoleId,
                    RoleName = u.RoleName
                }).ToList()
            };
            return PartialView("_EditPartialView", promoUserViewmodel);
         }

        [HttpPost]
        public async Task<IActionResult> EditEmployee([FromBody] PromoteEmployeeViewModel promoteEmployee)
        {
            var userrequetsDto = new PromoteEmployeeDTO
            {
                UserId = promoteEmployee.UserId,
                UserName = promoteEmployee.UserName,
                Email = promoteEmployee.Email,
                PhoneNumber = promoteEmployee.PhoneNumber,
                Role = promoteEmployee?.RoleId
            };
            var userreulst = await _userManagementService.EditEmployee(userrequetsDto);
            if (userreulst.Success)
                return Json(new { success = true, message = userreulst.Message });

            return Json(new { success = false, message = userreulst.Message });
        }
    }
}
