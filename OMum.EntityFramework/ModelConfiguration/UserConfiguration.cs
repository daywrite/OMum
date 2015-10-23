using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMum.Initialize;
using OMum.Users;

namespace OMum.ModelConfiguration
{
    public class UserConfiguration : EntityConfigurationBase<User, long>
    {
        public UserConfiguration()
        {
            ToTable("a_user");
        }
    }
}
