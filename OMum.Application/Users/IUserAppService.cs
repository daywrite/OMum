using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMum.Users.Dto;

namespace OMum.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
        PagedResultOutput<UserDto> GetUsers(GetUserInput input);
        Task SaveUser(UserDto input);
        Task DeleteUser(int UserId);
        Task<UserDto> GetUser(int UserId);
        Task SaveRole(UserDto input);
        Task<IList<string>> GetUserPermissions(long UserId);
    }
}