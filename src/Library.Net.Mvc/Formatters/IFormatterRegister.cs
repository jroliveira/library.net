using System.Net.Http.Formatting;

namespace Library.Net.Mvc.Formatters {

    public interface IFormatterRegister {

        void Register(MediaTypeFormatterCollection formatters);
    }
}