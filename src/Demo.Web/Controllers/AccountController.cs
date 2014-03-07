using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Demo.Domain.Entities;
using Demo.Domain.Services;
using Demo.Infrastructure.Data.Queries;
using Demo.Web.Lib.Extensions;
using Demo.Web.Models.Account;
using Library.Net.Data;
using Library.Net.Mvc.Attributes;
using Library.Net.Mvc.Controllers;

namespace Demo.Web.Controllers {

    public class AccountController : BaseController {

        private readonly IQueryFactory _queryFactory;
        private readonly IEmailService _emailService;

        public AccountController(IQueryFactory queryFactory, IEmailService emailService) {
            _queryFactory = queryFactory;
            _emailService = emailService;
        }

        private Account GetAccount(string email) {
            var query = _queryFactory.CreateQuery<AccountGetByEmailQuery>();
            query.Email = email;
            return query.GetResult();
        }

        private bool EmailExists(string email) {
            var query = _queryFactory.CreateQuery<AccountGetByEmailQuery>();
            query.Email = email;
            return query.GetResult() != null;
        }

        #region ajax only

        [HttpGet]
        [AjaxOnly]
        public ActionResult CheckUserEmailNonexistence(string email) {
            var created = EmailExists(email);
            return !created
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json("E-mail já cadastrado.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult CheckUserEmailExistence(string email) {
            var created = EmailExists(email);
            return created
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json("E-mail não esta cadastrado.", JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            try {
                //TODO: Salva.

                Success("Conta salva com sucesso!");
            }
            catch {
                Error("Erro ao salvar a conta!");
            }

            return RedirectToAction("LogOn", "Login");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit() {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult ForgotPassword() {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            var account = GetAccount(viewModel.Email);
            if (account == null) return Error("E-mail não esta cadastrado.", View(viewModel));

            account.NewPassword();

            string body;
            using (var reader = new StreamReader(string.Format(@"{0}\Templates\email.html", Server.GetRootPath()), Encoding.UTF7))
                body = reader.ReadToEnd();

            _emailService.Send(viewModel.Email, "Recuperação de senha", string.Format(body, account.Password));

            //TODO: Salva.

            return Information("A nova senha foi enviada para o email informado.", RedirectToAction("LogOn", "Login"));
        }

        [HttpGet]
        [Authorize]
        public ActionResult ChangePassword() {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            var query = _queryFactory.CreateQuery<AccountGetByIdQuery>();
            query.Id = Convert.ToInt64(User.Identity.Name);
            var account = query.GetResult();
            account.ChangePassword(viewModel.OldPassword, viewModel.NewPassword);

            //TODO: Salvar.

            return Information("Sua senha foi alterada com sucesso.", RedirectToAction("Index", "Home"));
        }
    }
}
