using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMum.Roles.Dto;

namespace OMum.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
        PagedResultOutput<RoleDto> GetRoles(GetRoleInput input);
        Task SaveRole(RoleDto input);
        Task<List<string>> GetRolePermissions(int RoleId);
    }
}
