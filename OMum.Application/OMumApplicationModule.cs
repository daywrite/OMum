using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using OMum.Authorization;
using OMum.Configuration;

namespace OMum
{
    [DependsOn(typeof(OMumCoreModule), typeof(AbpAutoMapperModule))]
    public class OMumApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //注入Permission
            Configuration.Authorization.Providers.Add<OMumAuthorizationProvider>();
            //注入列表默认提取
            Configuration.Settings.Providers.Add<MySettingProvider>();
        }
    }
}
