using System.Web.Script.Serialization;
using Library.Net.Mvc.Authentication;

namespace Demo.Web.Lib.Authentication {

    public class AuthenticatedUser : IAuthenticatedUser {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString() {
            var serializer = new JavaScriptSerializer();
            var account = this;

            return serializer.Serialize(account);
        }

        public static AuthenticatedUser FromString(string text) {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<AuthenticatedUser>(text);
        }
    }
}