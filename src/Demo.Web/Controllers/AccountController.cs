using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Demo.Domain.Entities;
using Demo.Domain.Services;
using Demo.Infrastructure.Data.Queries.AccountQuery;
using Demo.Web.Models.Account;
using Library.Net.Data;
using Library.Net.Mvc.Attributes;
using Library.Net.Mvc.Controllers;
using Library.Net.Mvc.Extensions;

namespace Demo.Web.Controllers {

    public class AccountController : BaseController {

        private readonly IQueryFactory _queryFactory;
        private readonly IEmailService _emailService;

        public AccountController(IQueryFactory queryFactory, IEmailService emailService) {
            _queryFactory = queryFactory;
            _emailService = emailService;
        }

        private Account GetAccount(string email) {
            var query = _queryFactory.CreateQuery<GetByEmailQuery>();
            return query.GetResult(email);
        }

        private bool EmailExists(string email) {
            var query = _queryFactory.CreateQuery<GetByEmailQuery>();
            return query.GetResult(email) != null;
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
        [AllowAnonymous]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(CreateViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            try {
                //TODO: Criar conta.

                Success("Conta criada com sucesso!");
            }
            catch {
                Error("Erro ao criar a conta!");
            }

            return RedirectToAction("LogOn", "Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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
        public ActionResult Edit() {
            var viewModel = new EditViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            try {
                //TODO: Editar conta.

                Success("Conta editada com sucesso!");
            }
            catch {
                Error("Erro ao editar a conta!");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword() {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            var query = _queryFactory.CreateQuery<GetByIdQuery>();
            var account = query.GetResult(Convert.ToInt64(User.Identity.Name));
            account.ChangePassword(viewModel.OldPassword, viewModel.NewPassword);

            //TODO: Salvar.

            return Information("Sua senha foi alterada com sucesso.", RedirectToAction("Index", "Home"));
        }
    }
}
