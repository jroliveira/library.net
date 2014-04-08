namespace Demo.Infrastructure.Logging {

    public interface ILogger {

        void Register(LogAction action);
    }

    public class Logger : ILogger {

        public void Register(LogAction action) { }
    }
}
