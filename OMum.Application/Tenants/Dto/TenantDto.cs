using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMum.MultiTenancy;

namespace OMum.Tenants.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantDto : CreationAuditedEntityDto
    {
          // 摘要: 
        //     "Default".
        public const string DefaultTenantName = "Default";
        //
        // 摘要: 
        //     Max length of the Abp.MultiTenancy.AbpTenant<TTenant,TUser>.Name property.
        public const int MaxNameLength = 128;
        //
        // 摘要: 
        //     Max length of the Abp.MultiTenancy.AbpTenant<TTenant,TUser>.TenancyName property.
        public const int MaxTenancyNameLength = 64;
        //
        // 摘要: 
        //     "^[a-zA-Z][a-zA-Z0-9_-]{1,}$".
        public const string TenancyNameRegex = "^[a-zA-Z][a-zA-Z0-9_-]{1,}$";

        // 摘要: 
        //     Is this tenant active? If as tenant is not active, no user of this tenant
        //     can use the application.
        public bool IsActive { get; set; }
        //
        // 摘要: 
        //     Display name of the Tenant.
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        //
        // 摘要: 
        //     Tenancy name. This property is the UNIQUE name of this Tenant.  It can be
        //     used as subdomain name in a web application.
        [Required]
        [StringLength(64)]
        public string TenancyName { get; set; }
    }
}
