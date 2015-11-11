using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OMum.Users.Dto
{
    public class UpdateUserPermissionsInput : IInputDto
    {
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
