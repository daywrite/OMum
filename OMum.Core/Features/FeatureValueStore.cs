using Abp.Application.Features;
using OMum.Authorization.Roles;
using OMum.MultiTenancy;
using OMum.Users;

namespace OMum.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}