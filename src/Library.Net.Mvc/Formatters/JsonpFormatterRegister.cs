using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Library.Net.Mvc.Formatters {

    public class JsonpFormatterRegister : IFormatterRegister {

        public void Register(MediaTypeFormatterCollection formatters) {
            formatters.Remove(formatters.JsonFormatter);
            formatters.Insert(0, new JsonpFormatter {
                SerializerSettings = new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });
        }
    }
}
