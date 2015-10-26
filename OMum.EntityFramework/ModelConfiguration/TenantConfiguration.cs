using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMum.Initialize;
using OMum.MultiTenancy;

namespace OMum.ModelConfiguration
{
     public class TenantConfiguration : EntityConfigurationBase<Tenant, int>
    {
        public TenantConfiguration()
        {
            ToTable("a_tenant");
        }
    }
}
