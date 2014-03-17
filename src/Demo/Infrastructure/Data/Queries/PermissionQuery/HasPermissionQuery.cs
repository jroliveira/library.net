using System.Linq;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.PermissionQuery {

    public class RequestParam {

        public string User { get; set; }
        public string Url { get; set; }

        public RequestParam(string user, string url) {
            User = user;
            Url = url;
        }
    }

    public interface IHasPermissionQuery : IQuery<bool, RequestParam> { }

    public class HasPermissionQuery : IHasPermissionQuery {

        public bool GetResult(RequestParam param) {
            var resources = new[] { "/", "/sair", "/conta/alterar-senha" };

            return resources.Any(r => r.Equals(param.Url)) && param.User.Equals("0");
        }
    }
}
