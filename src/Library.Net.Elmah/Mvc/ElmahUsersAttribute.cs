using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Library.Net.Mvc.Authentication;

namespace Library.Net.Elmah.Mvc {

    public class ElmahUsersAttribute : ActionMethodSelectorAttribute {

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) {
            ICurrentAuthenticatedUser<IAuthenticatedUser> currentAuthenticatedUser = new CurrentAuthenticatedUser<IAuthenticatedUser>();
            var authenticatedUser = currentAuthenticatedUser.Get();
            var elmahUsers = ConfigurationManager.AppSettings["Elmah:Users"];
            return elmahUsers.Split(',').Any(authenticatedUser.Id.ToString(CultureInfo.InvariantCulture).Equals);
        }
    }
}