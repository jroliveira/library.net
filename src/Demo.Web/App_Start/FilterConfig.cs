using System.Web.Mvc;
using Demo.Web.Lib.Attributes;
using Library.Net.IoC;

namespace Demo.Web.App_Start {

    public class FilterConfig {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(DependencyContainerHelper.Get<AllowAttribute>());
        }
    }
}