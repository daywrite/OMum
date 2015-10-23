using Abp.Authorization.Roles;
using OMum.MultiTenancy;
using OMum.Users;

namespace OMum.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}