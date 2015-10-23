using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using OMum.EntityFramework;

namespace OMum
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(OMumCoreModule))]
    public class OMumDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
