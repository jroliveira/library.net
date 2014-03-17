using System;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Demo.Infrastructure.Data.Queries.PermissionQuery;

namespace Demo.Web.Lib.Attributes {

    public class AllowAttribute : AuthorizeAttribute {

        private readonly IHasPermissionQuery _hasPermissionQuery;

        public AllowAttribute(IHasPermissionQuery hasPermissionQuery) {
            _hasPermissionQuery = hasPermissionQuery;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            if (httpContext == null) throw new ArgumentNullException("httpContext");

            var user = httpContext.User;
            if (!user.Identity.IsAuthenticated) return false;

            if (httpContext.Request.Url == null) return false;
            var url = httpContext.Request.Url.AbsolutePath;

            var allow = _hasPermissionQuery.GetResult(new RequestParam(user.Identity.Name, url));
            if (!allow) return false;

            return base.AuthorizeCore(httpContext);
        }
    }
}
