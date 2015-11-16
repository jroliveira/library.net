using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Library.Net.Mvc.Authentication
{
    public class CurrentAuthenticatedUser<T> : ICurrentAuthenticatedUser<T>
        where T : IAuthenticatedUser
    {
        private static T Deserialize(string data)
        {
            var serializer = new JavaScriptSerializer();

            return serializer.Deserialize<T>(data);
        }

        private static string Serialize(T authenticatedUser)
        {
            var serializer = new JavaScriptSerializer();

            return serializer.Serialize(authenticatedUser);
        }

        public T Get()
        {
            var identity = HttpContext.Current.User.Identity as FormsIdentity;

            if (identity == null)
            {
                throw new NullReferenceException("Current.User.Identity is not FormsIdentity or is null.");
            }

            return Deserialize(identity.Ticket.UserData);
        }

        public void Create(T authenticatedUser)
        {
            var data = Serialize(authenticatedUser);

            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                                                       authenticatedUser.Id,
                                                       DateTime.Now,
                                                       DateTime.Now.AddMinutes(30),
                                                       false,
                                                       data,
                                                       FormsAuthentication.FormsCookiePath);

            var hash = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
