using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Localization;

namespace OMum.Authorization
{
    public class OMumAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //TODO: Localize (Change FixedLocalizableString to LocalizableString)
            context.CreatePermission("GetAnimals", new FixedLocalizableString("GetAnimals"));
            context.CreatePermission("CanQueryCount", new FixedLocalizableString("CanQueryCount"), isGrantedByDefault: true);

            //
            var ModuleOMunManage = context.CreatePermission("ModuleOMunManage", new FixedLocalizableString("ModuleOMunManage"));
            ModuleOMunManage.CreateChildPermission("Administration.TenantManagement.SuperOwner", new FixedLocalizableString("Administration.TenantManagement.SuperOwner"));

            var TenantManage = ModuleOMunManage.CreateChildPermission("TenantManage", new FixedLocalizableString("TenantManage"));

            TenantManage.CreateChildPermission("View Tenants", new FixedLocalizableString("View Tenants"));
            TenantManage.CreateChildPermission("Create Tenants", new FixedLocalizableString("Create Tenants"));
            TenantManage.CreateChildPermission("Edit Tenants", new FixedLocalizableString("Edit Tenants"));
            TenantManage.CreateChildPermission("Delete Tenants", new FixedLocalizableString("Delete Tenants"));

            TenantManage.CreateChildPermission("Update TenantSetting", new FixedLocalizableString("Update TenantSetting"));

        }
    }
}
