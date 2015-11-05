using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Dynamic;

using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using OMum.Tenants.Dto;
using System.Threading.Tasks;
using Abp.Authorization;
using OMum.MultiTenancy;

namespace OMum.Tenants
{
    [AbpAuthorize]
    public class TenantAppService : OMumAppServiceBase, ITenantAppService
    {
        public TenantAppService()
        {
        }
        public async Task<PagedResultOutput<TenantDto>> GetTenants(GetTenantInput input)
        {
            var querys = TenantManager.Tenants.WhereIf(!string.IsNullOrEmpty(input.TenantName), u => u.TenancyName.Contains(input.TenantName) || u.Name.Contains(input.TenantName));
            var TotalCount = querys.Count();
            var users = querys.OrderBy(input.Sorting).PageBy(input).ToList();

            var id = AbpSession.TenantId;
            return new PagedResultOutput<TenantDto>()
            {
                TotalCount = TotalCount,
                Items = users.MapTo<List<TenantDto>>()
            };
        }

        Task<TenantDto> ITenantAppService.GetTenant(int? TenantId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTenant(CreateTenantInput input)
        {
            CheckErrors(await TenantManager.CreateAsync(new Tenant() { Name = input.Name, TenancyName = input.TenancyName, IsActive = true }));           
        }

        Task ITenantAppService.UpdateTenant(TenantDto tenant)
        {
            throw new NotImplementedException();
        }

        Task ITenantAppService.DeleteTenant(int TenantId)
        {
            throw new NotImplementedException();
        }
    }
}
