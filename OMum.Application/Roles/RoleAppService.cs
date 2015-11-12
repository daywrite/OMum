using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using OMum.Authorization.Roles;
using OMum.Roles.Dto;
using System.Linq.Dynamic;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using System.Collections.Generic;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using OMum.MultiTenancy;
using Abp;
using Abp.Application.Services.Dto;
namespace OMum.Roles
{
    /* THIS IS JUST A SAMPLE. */
    public class RoleAppService : OMumAppServiceBase,IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;

        public RoleAppService(RoleManager roleManager, IPermissionManager permissionManager)
        {
            _roleManager = roleManager;
            _permissionManager = permissionManager;
        }

        public async Task UpdateRolePermissions(UpdateRolePermissionsInput input)
        {
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var role = await _roleManager.GetRoleByIdAsync(input.RoleId);

                var grantedPermissions = PermissionManager
                    .GetAllPermissions()
                    .Where(p => input.GrantedPermissionNames.Contains(p.Name))
                    .ToList();

                await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
            }

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public PagedResultOutput<RoleDto> GetRoles(GetRoleInput input)
        {
            //var test = ;
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var querys = _roleManager.Roles.WhereIf(true, r => r.TenantId == input.TenantId).WhereIf(!string.IsNullOrEmpty(input.RoleDisplayName), u => u.DisplayName.Contains(input.RoleDisplayName));
                var TotalCount = querys.Count();
                var users = querys.OrderBy(input.Sorting).PageBy(input)
                     .Skip((input.pageIndex - 1) * input.pageSize)
                     .Take(input.pageSize)
                     .ToList();
                return new Abp.Application.Services.Dto.PagedResultOutput<RoleDto>()
                {
                    TotalCount = TotalCount,
                    Items = users.MapTo<List<RoleDto>>()
                };
            }
        }

        [UnitOfWork]
        public async Task SaveRole(RoleDto input)
        {
            var role = new Role();
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                CheckErrors(await _roleManager.CheckDuplicateRoleNameAsync(input.Id, input.Name, input.DisplayName));
                if (input.Id > 0)
                {
                    //if (!PermissionChecker.IsGranted("Edit Roles"))
                    //{
                    //    throw new AbpAuthorizationException("need Permission [Edit Roles]");
                    //}
                    role = await _roleManager.GetRoleByIdAsync(input.Id);
                    role.Name = input.Name;
                    role.DisplayName = input.DisplayName;
                    role.IsDefault = input.IsDefault;
                    role.IsStatic = input.IsStatic;
                    role.TenantId = input.TenantId;
                    CheckErrors(await _roleManager.UpdateAsync(role));
                }
                else
                {
                    //if (!PermissionChecker.IsGranted("Create Roles"))
                    //{
                    //    throw new AbpAuthorizationException("need Permission [Create Roles]");
                    //}
                    role.Name = input.Name;
                    role.DisplayName = input.DisplayName;
                    role.IsDefault = input.IsDefault;
                    role.IsStatic = input.IsStatic;
                    role.TenantId = input.TenantId;

                    CheckErrors(await _roleManager.CreateAsync(role));
                    //_roleRepository.InsertAndGetId(role);//new Role() { DisplayName = "sdfsd", Name = "sdfs", TenantId = input.TenantId });
                }
                if (input.IsDefault)
                {
                    var defaultRoles = _roleManager.Roles.Where(r => r.IsDefault == true && r.Id != input.Id && r.TenantId == input.TenantId).ToList();
                    foreach (var item in defaultRoles)
                    {
                        item.IsDefault = false;
                        CheckErrors(await _roleManager.UpdateAsync(item));
                    }
                }


                await CurrentUnitOfWork.SaveChangesAsync();
            }

        }

        public async Task<List<string>> GetRolePermissions(int RoleId)
        {
            using (this.CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var permissions = (await _roleManager.GetGrantedPermissionsAsync(RoleId));
                return permissions.Select(p => p.Name).ToList();
            }
        }
    }
}