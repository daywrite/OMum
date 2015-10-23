using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMum.Authorization.Roles;
using OMum.Initialize;

namespace OMum.ModelConfiguration
{
    public class RoleConfiguration : EntityConfigurationBase<Role, int>
    {
        public RoleConfiguration()
        {
            ToTable("a_role");
        }
    }
}
