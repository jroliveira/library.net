using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Library.Net.Mvc.Authentication;

namespace Library.Net.Elmah.Mvc {

    public class ElmahUsersAttribute : ActionMethodSelectorAttribute {

        private ICurrentAuthenticatedUser<IAuthenticatedUser> _currentAuthenticatedUser = new CurrentAuthenticatedUser<IAuthenticatedUser>();
        public void SetCurrentAuthenticatedUser(ICurrentAuthenticatedUser<IAuthenticatedUser> currentAuthenticatedUser) {
            _currentAuthenticatedUser = currentAuthenticatedUser;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) {
            var authenticatedUser = _currentAuthenticatedUser.Get();
            var elmahUsers = ConfigurationManager.AppSettings["Elmah:Users"];
            return elmahUsers.Split(',').Any(authenticatedUser.Id.ToString(CultureInfo.InvariantCulture).Equals);
        }
    }
}