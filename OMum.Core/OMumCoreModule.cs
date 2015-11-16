using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Zero;
using Abp.Zero.Configuration;
using OMum.Authorization.Roles;
using OMum.Configuration;

namespace OMum
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class OMumCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    OMumConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "OMum.Localization.Source"
                        )
                    )
                );
            Configuration.Settings.Providers.Add<OMumSettingProvider>();
            //默认租户登陆
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Host));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Admin, MultiTenancySides.Tenant));
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Tenant.Member, MultiTenancySides.Tenant));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
