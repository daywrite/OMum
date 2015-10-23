using Abp.MultiTenancy;
using OMum.Authorization.Roles;
using OMum.Editions;
using OMum.Users;

namespace OMum.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}