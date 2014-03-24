using System;
using System.Collections.Generic;

namespace Demo.Infrastructure.Logging {

    public class LogAction {

        public int Id { get; set; }

        public string Action { get; set; }
        public string Controller { get; set; }
        public string Method { get; set; }

        public string Username { get; set; }
        public string IpAddress { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<LogParameter> Parameters { get; set; }
    }
}