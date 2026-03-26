using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
{
    public class UserManagementService : IUserManagementService
    {
        private readonly EShopDbContext _eShopDbContext;

        public UserManagementService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }
        public GetAllUserResultDTO GetAllUser()
        {
            var userDto = _eShopDbContext.Users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Role = _eShopDbContext.UserRoles
                    .Where(ur => ur.UserId == u.Id)
                    .Join(_eShopDbContext.Roles,
                          ur => ur.RoleId,
                          r => r.Id,
                          (ur, r) => r.Name)
                    .FirstOrDefault(),
            }).ToList();
            var roleDto = _eShopDbContext.Roles.Select(r => new RoleDTO
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();
            return new GetAllUserResultDTO
                {
                   User = userDto,
                   Roledto = roleDto
                };
        }
        public async Task<UserDTO> GetUserInfo (string UserId)
        {
            var user = await _eShopDbContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            var roles =  (from r in _eShopDbContext.Roles
                              select new RoleDTO
                              {
                                  RoleId = r.Id,
                                  RoleName = r.Name
                              }).ToList();

            var userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                roledto = roles
            };
            return userDTO;
        }
        public async Task<ServiceResult> AddEmployee (PromoteEmployeeDTO promoteEmployeeDTO)
        {
            var existingEmployee = await _eShopDbContext.Employees.FirstOrDefaultAsync(e => e.UserId == promoteEmployeeDTO.UserId);
            if (existingEmployee != null)
            {
                existingEmployee.Salary = promoteEmployeeDTO.Salary;
                existingEmployee.Position = promoteEmployeeDTO.Position;
                _eShopDbContext.Employees.Update(existingEmployee);
            }
            else
            {
                var employee = new Employee
                {
                    UserId = promoteEmployeeDTO.UserId,
                    Salary = promoteEmployeeDTO.Salary,
                    Email = promoteEmployeeDTO.Email,
                    FullName = promoteEmployeeDTO.FullName,
                    Position = promoteEmployeeDTO.Position,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };
                _eShopDbContext.Employees.Add(employee);
            }
            var existingUserRole = await _eShopDbContext.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == promoteEmployeeDTO.UserId);
            if ( existingUserRole == null )
            {
                var userRole = new IdentityUserRole<string>
                {
                    UserId = promoteEmployeeDTO.UserId,
                    RoleId = promoteEmployeeDTO.RoleId
                };
                _eShopDbContext.UserRoles.Add(userRole);
            }
            else
            {
                _eShopDbContext.UserRoles.Remove(existingUserRole);
                var newRole = new IdentityUserRole<string>
                {
                    UserId = promoteEmployeeDTO.UserId,
                    RoleId = promoteEmployeeDTO.RoleId
                };
                _eShopDbContext.UserRoles.Add(newRole);
            }
            var existingUser = await _eShopDbContext.Users.FirstOrDefaultAsync(u => u.Id == promoteEmployeeDTO.UserId);
            if (existingUser != null)
            {
                existingUser.PhoneNumber = promoteEmployeeDTO.PhoneNumber;
                _eShopDbContext.Users.Update(existingUser);
            }    
            await _eShopDbContext.SaveChangesAsync();
            return new ServiceResult
                {
                    Success = true,
                    Message = "Them thanh cong "
                };
           
        }
        public async Task<List<UserDTO>> LoadUser(UserRequestDTO userRequestDTO)
        {
            var query = from u in _eShopDbContext.Users
                        join ur in _eShopDbContext.UserRoles
                            on u.Id equals ur.UserId into urGroup
                        from ur in urGroup.DefaultIfEmpty()

                        join r in _eShopDbContext.Roles
                            on ur.RoleId equals r.Id into rGroup
                        from r in rGroup.DefaultIfEmpty()

                        select new { u, ur, r };
            if (!string.IsNullOrEmpty(userRequestDTO.UserName))
            {
                query = query.Where(x => x.u.UserName.Contains(userRequestDTO.UserName));
            }

            if (!string.IsNullOrEmpty(userRequestDTO.RoleId))
            {
                query = query.Where(x => x.ur.RoleId == userRequestDTO.RoleId);
            }

            var result = await query.Select(x => new UserDTO
            {
                Id = x.u.Id,
                Email = x.u.Email,
                UserName = x.u.UserName,
                PhoneNumber = x.u.PhoneNumber,
                Role = x.r.Name 
            }).ToListAsync();

            return result;
        }
    }
}
