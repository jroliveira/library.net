using System;
using System.Web;
using System.Web.Mvc;
using Demo.Infrastructure.Data.Queries.PermissionQuery;

namespace Demo.Web.Lib.Attributes {

    public class AllowAttribute : AuthorizeAttribute {

        private readonly IHasPermissionQuery _hasPermissionQuery;

        public AllowAttribute(IHasPermissionQuery hasPermissionQuery) {
            _hasPermissionQuery = hasPermissionQuery;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
            var user = filterContext.HttpContext.User;
            if (!user.Identity.IsAuthenticated) {
                filterContext.Result = new RedirectToRouteResult("LogOn", null);
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            if (httpContext == null) throw new ArgumentNullException("httpContext");

            var user = httpContext.User;
            if (!user.Identity.IsAuthenticated) return false;

            var routeData = httpContext.Request.RequestContext.RouteData;

            var action = routeData.GetRequiredString("action");
            if (string.IsNullOrEmpty(action)) return false;

            var controller = routeData.GetRequiredString("controller");
            if (string.IsNullOrEmpty(controller)) return false;

            var allow = _hasPermissionQuery.GetResult(new RequestParam(user.Identity.Name, action, controller));
            if (!allow) return false;

            return base.AuthorizeCore(httpContext);
        }
    }
}
