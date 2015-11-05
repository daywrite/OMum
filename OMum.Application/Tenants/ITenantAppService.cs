using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OMum.Tenants.Dto;

namespace OMum.Tenants
{
    public interface ITenantAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有租户
        /// 全租户管理员拥有此访问权限
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <returns></returns>
        Task<PagedResultOutput<TenantDto>> GetTenants(GetTenantInput input);
        /// <summary>
        /// 获取单个租户信息
        /// 访问权限：
        /// 全租户管理员
        /// 租户管理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize("AdminTenancyOwner")]
        Task<TenantDto> GetTenant(int? TenantId);
        /// <summary>
        /// 创建单个租户
        /// </summary>
        /// <param name="tenant"></param>
        /// <returns></returns>
        Task CreateTenant(CreateTenantInput input);
        /// <summary>
        /// 更新设置租户信息
        /// </summary>
        /// <param name="tenant">更新</param>
        /// <returns></returns>
        Task UpdateTenant(TenantDto tenant);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TenantId"></param>
        /// <returns></returns>
        Task DeleteTenant(int TenantId);

    }
}

