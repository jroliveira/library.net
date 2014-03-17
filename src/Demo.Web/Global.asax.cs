using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Demo.Infrastructure.IoC;
using Demo.Web.App_Start;
using Library.Net.IoC;
using Library.Net.IoC.Mvc;
using Library.Net.Mvc.Formatters;

namespace Demo.Web {

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication {

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            DependencyContainerHelper.Init(new StructureMapContainer());
            ControllerBuilder.Current.SetControllerFactory(new DependencyContainerControllerFactory());

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new JsonpFormatterRegister().Register(GlobalConfiguration.Configuration.Formatters);
        }
    }
}