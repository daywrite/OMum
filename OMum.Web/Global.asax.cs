using System;
using Abp.Dependency;
using Abp.Web;
using Castle.Facilities.Logging;
using OBear.Initialize;
using OMum.Initialize;

namespace OMum.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IFrameworkInitializer initializer = new MvcFrameworkInitializer() { };
            initializer.Initialize();

            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }
    }
}
