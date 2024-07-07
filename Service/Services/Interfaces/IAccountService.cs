using Service.DTOs.Accounts;
using Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResponse> SignUpAsync(RegisterDto model);
        Task CreateRolesAsync();
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserRoleResponse> AddRoleToUserAsync(UserRoleDto user);
        Task<IEnumerable<RoleDto>> GetRolesAsync();
        Task<LoginResponse> SignInAsync(LoginDto model);
    }
}
