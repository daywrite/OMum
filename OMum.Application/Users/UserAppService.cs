using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Dynamic;

using Microsoft.AspNet.Identity;

using Abp.AutoMapper;
using Abp.Authorization.Users;
using Abp.Authorization;
using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using OMum.Users.Dto;

namespace OMum.Users
{
    [AbpAuthorize]
    public class UserAppService : OMumAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await _userManager.RemoveFromRoleAsync(userId, roleName));
        }

        public PagedResultOutput<UserDto> GetUsers(GetUserInput input)
        {
            //ÅÐ¶ÏÊÇ·ñÓµÓÐ½ÇÉ«
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MustHaveTenant))
            {
                var TotalCount = 0;

                var querys = UserManager.Users.WhereIf(!string.IsNullOrEmpty(input.UserName), u => u.UserName.Contains(input.UserName));
                TotalCount = querys.Count();
                var users = querys
                     .OrderBy(input.Sorting)
                     .PageBy(input)
                     .Skip((input.pageIndex - 1) * input.pageSize)
                     .Take(input.pageSize)
                     .ToList();

                return new PagedResultOutput<UserDto>()
                {
                    TotalCount = TotalCount,
                    Items = users.MapTo<List<UserDto>>()
                };
            }

        }
    }
}