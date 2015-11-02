using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using OMum.Initialize;

namespace OMum.ModelConfiguration
{
    public class UserPermissionConfiguration : EntityConfigurationBase<UserPermissionSetting, long>
    {
        public UserPermissionConfiguration()
        {
            ToTable("a_permission");
        }
    }
}
