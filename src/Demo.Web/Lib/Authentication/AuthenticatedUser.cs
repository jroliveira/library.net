using Library.Net.Mvc.Authentication;

namespace Demo.Web.Lib.Authentication {

    public class AuthenticatedUser : IAuthenticatedUser {

        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}