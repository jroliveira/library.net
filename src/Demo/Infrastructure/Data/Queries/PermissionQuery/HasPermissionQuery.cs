using System.Linq;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.PermissionQuery {

    public class RequestParam {

        public string User { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }

        public RequestParam(string user, string action, string controller) {
            User = user;
            Action = action;
            Controller = controller;
        }
    }

    public interface IHasPermissionQuery : IQuery<bool, RequestParam> { }

    public class HasPermissionQuery : IHasPermissionQuery {

        public bool GetResult(RequestParam param) {
            var resources = new[] {
                new { Controller = "Home", Action = "Index" },
                new { Controller = "Login", Action = "LogOff" },
                
                new { Controller = "Account", Action = "Index" },
                new { Controller = "Account", Action = "Edit" },
                new { Controller = "Account", Action = "ChangePassword" },

                new { Controller = "Page", Action = "Index" },
                new { Controller = "Page", Action = "Create" },
                new { Controller = "Page", Action = "Edit" },
                new { Controller = "Page", Action = "Delete" },

                new { Controller = "Permission", Action = "Index" },
                new { Controller = "Permission", Action = "Permission" }
            };

            return resources.Any(r => r.Action.Equals(param.Action) && r.Controller.Equals(param.Controller)) && param.User.Equals("0");
        }
    }
}
