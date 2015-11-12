using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMum.Authorization.Roles;

namespace OMum.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class RoleDto : CreationAuditedEntityDto
    {
        // 摘要: 
        //     Display name of this role.
        [Required]
        [StringLength(64)]
        public virtual string DisplayName { get; set; }
        //
        // 摘要: 
        //     Is this role will be assigned to new users as default?
        public virtual bool IsDefault { get; set; }
        //
        // 摘要: 
        //     Is this a static role? Static roles can not be deleted, can not change their
        //     name.  They can be used programmatically.
        public virtual bool IsStatic { get; set; }
        //
        // 摘要: 
        //     Unique name of this role.
        [Required]
        [StringLength(32)]
        public virtual string Name { get; set; }

        //
        // 摘要: 
        //     Tenant's Id, if this role is a tenant-level role. Null, if not.
        public virtual int? TenantId { get; set; }
    }
}

