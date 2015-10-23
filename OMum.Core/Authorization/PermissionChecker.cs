using Abp.Authorization;
using OMum.Authorization.Roles;
using OMum.MultiTenancy;
using OMum.Users;

namespace OMum.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
