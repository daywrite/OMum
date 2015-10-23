using System.Threading.Tasks;
using Abp.Application.Services;
using OMum.Users.Dto;

namespace OMum.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}