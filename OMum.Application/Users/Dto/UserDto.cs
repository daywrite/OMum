using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMum.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : CreationAuditedEntityDto<long>
    {
        public UserDto()
        {
            this.GrantRoleNames = new List<string>();
        }
        // 摘要: 
        //     Authorization source name.  It's set to external authentication source name
        //     if created by an external source.  Default: null.
        [MaxLength(64)]
        public virtual string AuthenticationSource { get; set; }
        //
        // 摘要: 
        //     Email address of the user.  Email address must be unique for it's tenant.
        [Required]
        [StringLength(256)]
        public virtual string EmailAddress { get; set; }
        //
        // 摘要: 
        //     Confirmation code for email.
        [StringLength(128)]
        public virtual string EmailConfirmationCode { get; set; }
        //
        // 摘要: 
        //     Is this user active? If as user is not active, he/she can not use the application.
        public virtual bool IsActive { get; set; }
        //
        // 摘要: 
        //     Is the Abp.Authorization.Users.AbpUser<TTenant,TUser>.EmailAddress confirmed.
        public virtual bool IsEmailConfirmed { get; set; }
        //
        // 摘要: 
        //     The last time this user entered to the system.
        public virtual DateTime? LastLoginTime { get; set; }

        //
        // 摘要: 
        //     Name of the user.
        [Required]
        [StringLength(32)]
        public virtual string Name { get; set; }
        //
        // 摘要: 
        //     Password of the user.
        [Required]
        [StringLength(128)]
        public virtual string Password { get; set; }
        //
        // 摘要: 
        //     Reset code for password.  It's not valid if it's null.  It's for one usage
        //     and must be set to null after reset.
        [StringLength(328)]
        public virtual string PasswordResetCode { get; set; }

        //
        // 摘要: 
        //     Surname of the user.
        [Required]
        [StringLength(32)]
        public virtual string Surname { get; set; }

        //
        // 摘要: 
        //     Tenant Id of this user.
        public virtual int? TenantId { get; set; }
        //
        // 摘要: 
        //     User name.  User name must be unique for it's tenant.
        [Required]
        [StringLength(32)]
        public virtual string UserName { get; set; }
        /// <summary>
        /// 已经授权的角色
        /// </summary>
        public List<string> GrantRoleNames { get; set; }
        public List<string> AllRoleNames { get; set; }
    }
}

