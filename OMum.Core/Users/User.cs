using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using OMum.MultiTenancy;

namespace OMum.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
    }
}