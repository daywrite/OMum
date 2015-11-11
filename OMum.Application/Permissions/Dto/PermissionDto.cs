using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMum.Permissions.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class PermissionDto
    {
        /// <summary>
        /// Name
        /// </summary>

        public string Id { get; set; }
        public string Parent { get; set; }
        /// <summary>
        /// DisplayName
        /// </summary>
        public string Text { get; set; }
        public string Icon { get; set; }

        //
        // 摘要: 
        //     Is this permission granted by default.  Default value: false.
        public bool IsGrantedByDefault { get; set; }
    }
}
