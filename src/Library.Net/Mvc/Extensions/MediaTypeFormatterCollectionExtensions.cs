using System.Net.Http.Formatting;
using Library.Net.Mvc.Formatters;

namespace Library.Net.Mvc.Extensions {

    public static class MediaTypeFormatterCollectionExtensions {

        public static void Register(this MediaTypeFormatterCollection formatters, IFormatterRegister formatter) {
            formatter.Register(formatters);
        }
    }
}
