using System.Web.Mvc;

namespace Library.Net.Mvc.Attributes {

    public class NonAjaxOnlyAttribute : ActionMethodSelectorAttribute {

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo) {
            return !controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}