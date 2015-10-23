using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using OMum.Initialize;

namespace OMum.ModelConfiguration
{
    public class UserRoleConfiguration : EntityConfigurationBase<UserRole, long>
    {
        public UserRoleConfiguration()
        {
            ToTable("a_userrole");
        }
    }
}
   
