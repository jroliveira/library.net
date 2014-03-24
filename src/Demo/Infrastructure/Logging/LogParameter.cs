using System.Globalization;
using System.Text.RegularExpressions;

namespace Demo.Infrastructure.Logging {

    public class LogParameter {

        public LogParameter(string name, string value) {
            Name = name;
            Value = value;
        }

        public LogParameter(string name, int value)
            : this(name, value.ToString(CultureInfo.InvariantCulture)) { }

        public LogParameter(string name, bool value)
            : this(name, value.ToString(CultureInfo.InvariantCulture)) { }

        public LogParameter(Capture name, Capture value) {
            Name = name.Value;
            Value = value.Value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
