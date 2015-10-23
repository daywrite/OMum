using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace OMum
{
    [DependsOn(typeof(OMumCoreModule), typeof(AbpAutoMapperModule))]
    public class OMumApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
