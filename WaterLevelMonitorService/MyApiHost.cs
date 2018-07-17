using Ninject;
using Ninject.Web.Common.OwinHost;
//using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WaterLevelCheckerDomain.Domain;

namespace WaterLevelMonitorService
{
    class MyApiHost
    {

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            // config.Filters.Add(new UnhandledExceptionFilterAttribute(new Logger(new TimeService(),
            //     new CanGetConfigurations())));
            // config.MessageHandlers.Add(new LoggingMessageHandler(new Logger(new TimeService(),
            //new CanGetConfigurations())));


            appBuilder.UseNinjectMiddleware(CreateKernel).UseWebApi(config);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());
            //RegisterServices(kernel);

            return kernel;
        }

        //private static void RegisterServices(IKernel kernel)
        //{
        //    kernel.Bind<IGpsBeaconApiRepository>().To<GpsBeaconApiRepository>();
        //}
    }
}
