using Elmah;

namespace Library.Net.Elmah.Mvc {

    public interface IExceptionFilter {

        bool IsFiltered(ExceptionFilterEventArgs args);
    }
}