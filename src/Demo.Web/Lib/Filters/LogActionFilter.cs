using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Demo.Infrastructure.Logging;

namespace Demo.Web.Lib.Filters {

    public class LogActionFilter : ActionFilterAttribute {

        private readonly ILogger _logger;

        public LogActionFilter(ILogger logger) {
            _logger = logger;
        }

        private static IEnumerable<LogParameter> GetParameters(HttpRequestBase request) {
            var data = new StreamReader(request.InputStream).ReadToEnd();

            ICollection<LogParameter> parameters = new Collection<LogParameter>();

            var regex = new Regex(@"(?<parameter>(?<name>[^=&]+)\=(?<value>[^&]+))");
            var matches = regex.Matches(data);

            foreach (var match in matches.Cast<Match>().Where(match => match.Success))
                parameters.Add(new LogParameter(match.Groups["name"], match.Groups["value"]));

            return parameters;
        }

        private static string GetUser(HttpRequestBase request) {
            return request.LogonUserIdentity != null 
                ? request.LogonUserIdentity.Name 
                : string.Empty;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request.IsAjaxRequest()) {
                base.OnActionExecuting(filterContext);
                return;
            }

            ThreadPool.QueueUserWorkItem(delegate {
                var action = new LogAction {
                    Action = filterContext.ActionDescriptor.ActionName,
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Method = request.HttpMethod,
                    IpAddress = request.UserHostAddress,
                    Parameters = GetParameters(request),
                    Username = GetUser(request),
                    Date = filterContext.HttpContext.Timestamp
                };

                _logger.Register(action);
            });

            base.OnActionExecuting(filterContext);
        }
    }
}