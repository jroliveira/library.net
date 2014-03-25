using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using Demo.Domain.Entities;
using Demo.Infrastructure.Data.Queries.AccountQuery;
using Demo.Web.Lib.Authentication;
using Demo.Web.Models.Login;
using Library.Net.Data;
using Library.Net.Mvc.Authentication;
using Library.Net.Mvc.Controllers;

namespace Demo.Web.Controllers {

    public class LoginController : BaseController {

        private readonly IQueryFactory _queryFactory;

        private ICurrentAuthenticatedUser<AuthenticatedUser> _currentAuthenticatedUser = new CurrentAuthenticatedUser<AuthenticatedUser>();
        public void SetCurrentAuthenticatedUser(ICurrentAuthenticatedUser<AuthenticatedUser> currentAuthenticatedUser) {
            _currentAuthenticatedUser = currentAuthenticatedUser;
        }

        public LoginController(IQueryFactory queryFactory) {
            _queryFactory = queryFactory;
        }

        private Account GetAccount(string email) {
            var query = _queryFactory.CreateQuery<GetByEmailQuery>();
            return query.GetResult(email);
        }

        private bool IsValidReturnUrl(string returnUrl) {
            return !string.IsNullOrEmpty(returnUrl)
                   && Url.IsLocalUrl(returnUrl)
                   && returnUrl.Length > 1
                   && returnUrl.StartsWith("/")
                   && !returnUrl.StartsWith("//")
                   && !returnUrl.StartsWith("/\\");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOn() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOn(LogOnViewModel viewModel, string returnUrl) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            var account = GetAccount(viewModel.Email);
            if ((account == null) || (!account.IsValid(viewModel.Password)))
                return Attention("Usuário ou senha inválidos.", View(viewModel));

            var authenticatedUser = new AuthenticatedUser { Id = account.Id.ToString(CultureInfo.InvariantCulture), Email = account.Email, Password = account.Password };
            _currentAuthenticatedUser.Create(authenticatedUser);

            if (IsValidReturnUrl(returnUrl)) return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOff() {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn");
        }
    }
}
