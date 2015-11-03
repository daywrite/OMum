using System;
using Abp.Dependency;
using Abp.Reflection;
using Abp.Web;
using Castle.Facilities.Logging;
using OBear.Initialize;
using OMum.Initialize;

namespace Angle
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IFrameworkInitializer initializer = new MvcFrameworkInitializer() { };
            initializer.Initialize();

            //使用NLog日志
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));

            //使用CurrentDomainAssemblyFinder替代默认的WebAssemblyFinder,提升启动速度,但需要注意必须正确定义每个模块的依赖关系
            IocManager.Instance.RegisterIfNot<IAssemblyFinder, CurrentDomainAssemblyFinder>();

            base.Application_Start(sender, e);
        }
    }
}

