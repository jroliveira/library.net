using System.Reflection;
using System.Web.Mvc;

namespace Library.Net.Mvc.Attributes
{
    public class NonAjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return !controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}