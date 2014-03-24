using System.Web.Mvc;
using Demo.Web.Lib.Attributes;
using Demo.Web.Lib.Filters;
using Library.Net.IoC;

namespace Demo.Web.App_Start {

    public class FilterConfig {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(DependencyContainerHelper.Get<AllowAttribute>());
            filters.Add(DependencyContainerHelper.Get<LogActionFilter>());
        }
    }
}