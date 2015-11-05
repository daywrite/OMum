using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMum.Tenants.Dto
{
    public class CreateTenantOutput : IOutputDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Succeeded { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}
