using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Roles;
using OMum.Initialize;

namespace OMum.ModelConfiguration
{
    public class RolePermissionConfiguration : EntityConfigurationBase<RolePermissionSetting, long>
    {
        public RolePermissionConfiguration()
        {
            ToTable("a_permission");
        }
    }
}
