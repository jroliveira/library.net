using System.Web;
using Elmah;

namespace Library.Net.Elmah.Mvc {

    public class Error404ExceptionFilter : IExceptionFilter {

        public bool IsFiltered(ExceptionFilterEventArgs args) {
            var exception = args.Exception.GetBaseException() as HttpException;
            if (exception == null) return false;

            return exception.GetHttpCode() == 404;
        }
    }
}