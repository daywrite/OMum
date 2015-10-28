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
            context.CreatePermission("CanQueryCount", new FixedLocalizableString("Can create questions"), isGrantedByDefault: true);
        }
    }
}
