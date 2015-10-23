using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using OMum.Authorization.Roles;
using OMum.MultiTenancy;

namespace OMum.Users
{
    public class UserStore : AbpUserStore<Tenant, Role, User>
    {
        public UserStore(
            IRepository<User, long> userRepository,
            IRepository<UserLogin, long> userLoginRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<Role> roleRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager)
            : base(
              userRepository,
              userLoginRepository,
              userRoleRepository,
              roleRepository,
              userPermissionSettingRepository,
              unitOfWorkManager,
              cacheManager)
        {
        }
    }
}