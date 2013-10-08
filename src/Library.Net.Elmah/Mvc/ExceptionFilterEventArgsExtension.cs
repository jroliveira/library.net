using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elmah;

namespace Library.Net.Elmah.Mvc {

    public static class ExceptionFilterEventArgsExtension {

        public static void RunExceptionFilters(this ExceptionFilterEventArgs args, ICollection<IExceptionFilter> filters) {
            var exception = args.Exception.GetBaseException() as HttpException;
            if (exception == null) return;

            if (filters.Any(filter => filter.IsFiltered(args))) {
                args.Dismiss();
            }
        }
    }
}
