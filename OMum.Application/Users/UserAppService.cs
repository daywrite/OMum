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
using OMum.Authorization.Roles;

namespace OMum.Users
{
    [AbpAuthorize]
    public class UserAppService : OMumAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<Role, int> roleRepository;
        private readonly IRepository<UserRole, long> userroleRepository;

        RoleManager RoleManager;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager, RoleManager _RoleManager, IRepository<UserRole, long> _userroleRepository, IRepository<Role, int> _roleRepository)
        {
            this.RoleManager = _RoleManager;
            _userManager = userManager;
            _permissionManager = permissionManager;
            userroleRepository = _userroleRepository;
            roleRepository = _roleRepository;
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
        public async Task SaveRole(UserDto input)
        {
            var user = new User();
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var GrantRoleNames = input.GrantRoleNames;
                var grantRoleIds = roleRepository.GetAll().Where(r => r.TenantId == input.TenantId && GrantRoleNames.Contains(r.Name)).Select(r => r.Id).ToList();

                await userroleRepository.DeleteAsync(ur => ur.UserId == input.Id);
                grantRoleIds.ForEach(r =>
                {
                    userroleRepository.InsertAsync(new UserRole(input.Id, r));
                });

                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }
        public async Task SaveUser(UserDto input)
        {
            var user = new User();
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                //CheckErrors(await UserManager.CheckTenantyDuplicateUsernameOrEmailAddressAsync(input.Id, input.TenantId, input.UserName, input.EmailAddress));
                //var GrantRoleNames = input.GrantRoleNames;
                //var grantRoleIds = roleRepository.GetAll().Where(r => r.TenantId == input.TenantId && GrantRoleNames.Contains(r.Name)).Select(r => r.Id).ToList();
                if (input.Id > 0)
                {

                    user = await UserManager.GetUserByIdAsync(input.Id);
                    user.Name = input.Name;
                    user.Surname = input.Surname;
                    user.TenantId = input.TenantId;
                    user.EmailAddress = input.EmailAddress;
                    user.IsActive = input.IsActive;
                    user.UserName = input.UserName;
                    user.IsEmailConfirmed = input.IsEmailConfirmed;

                    var HavedRoles = (await UserManager.GetRolesAsync(input.Id)).ToList();
                    //HavedRoles.RemoveAll
                    //HavedRoles.ForEach(r => input.GrantRoleNames.Remove(r));
                    //await userRepository.UpdateAsync(user);
                    CheckErrors(await UserManager.UpdateAsync(user));
                }
                else
                {
                    user.Name = input.Name;
                    user.Surname = input.Surname;
                    user.TenantId = input.TenantId;
                    user.EmailAddress = input.EmailAddress;
                    user.IsActive = input.IsActive;
                    user.UserName = input.UserName;
                    user.Password = new PasswordHasher().HashPassword(string.IsNullOrEmpty(input.Password) ? "123qwe" : input.Password);
                    //var defaultRoles = RoleManager.Roles.Where(r => r.IsDefault == true && r.TenantId == input.TenantId).Select(r => r.Name);
                    //input.GrantRoleNames = defaultRoles.ToList();

                    //user.Id = await userRepository.InsertAndGetIdAsync(user);
                    CheckErrors(await UserManager.CreateAsync(user, string.IsNullOrEmpty(input.Password) ? "123qwe" : input.Password));
                }
                //await userroleRepository.DeleteAsync(ur => ur.UserId == input.Id);
                //grantRoleIds.ForEach(r =>
                //{
                //    userroleRepository.InsertAsync(new UserRole(input.Id, r));
                //});

                //CheckErrors(await UserManager.SetRoles(user, input.GrantRoleNames.ToArray()));
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int UserId)
        {
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var user = (await UserManager.GetUserByIdAsync(UserId));
                CheckErrors(await UserManager.DeleteAsync(user));
                await this.CurrentUnitOfWork.SaveChangesAsync();
            }
        }

        public async Task<UserDto> GetUser(int UserId)
        {
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var user = await UserManager.GetUserByIdAsync(UserId);
                var dto = user.MapTo<UserDto>();
                //dto.RoleNames =new List<string>();
                dto.GrantRoleNames = UserManager.GetRoles(UserId).ToList();

                dto.AllRoleNames = RoleManager.Roles.WhereIf(true, r => r.TenantId == user.TenantId).Select(r => r.Name).ToList();
                return dto;
            }
        }
    }
}