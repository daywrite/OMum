using System.Threading.Tasks;
using Abp.Application.Services;
using OMum.Roles.Dto;

namespace OMum.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
