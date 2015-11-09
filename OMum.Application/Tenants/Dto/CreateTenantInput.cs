using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMum.Tenants.Dto
{
    /// <summary>
    /// 新建tennat的dto
    /// </summary>
    public class CreateTenantInput : IInputDto
    {
        public int Id { get; set; }
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

        public bool IsActive { get; set; }
    }
}
