using Abp.MultiTenancy;
using OMum.Users;

namespace OMum.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}