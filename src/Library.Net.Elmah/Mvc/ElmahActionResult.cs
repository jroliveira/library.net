using System;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace Library.Net.Elmah.Mvc {

    public class ElmahActionResult : ActionResult {

        private readonly string _resouceType;

        public ElmahActionResult() : this(null) { }

        public ElmahActionResult(string resouceType) {
            _resouceType = resouceType;
        }

        public override void ExecuteResult(ControllerContext context) {
            var factory = new ErrorLogPageFactory();

            if (!string.IsNullOrEmpty(_resouceType)) {
                var pathInfo = "/" + _resouceType;
                context.HttpContext.RewritePath(FilePath(context), pathInfo, context.HttpContext.Request.QueryString.ToString());
            }

            var currentContext = GetCurrentContextAsHttpContext(context);

            var httpHandler = factory.GetHandler(currentContext, null, null, null);
            var httpAsyncHandler = httpHandler as IHttpAsyncHandler;

            if (httpAsyncHandler != null) {
                httpAsyncHandler.BeginProcessRequest(currentContext, r => { }, null);
                return;
            }

            httpHandler.ProcessRequest(currentContext);
        }

        private static HttpContext GetCurrentContextAsHttpContext(ControllerContext context) {
            return context.HttpContext.ApplicationInstance.Context;
        }

        private string FilePath(ControllerContext context) {
            return _resouceType != "stylesheet"
                       ? context.HttpContext.Request.Path.Replace(String.Format("/{0}", _resouceType), string.Empty)
                       : context.HttpContext.Request.Path;
        }
    }
}
