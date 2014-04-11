using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using Demo.Web.Models.Permission;
using Library.Net.Mvc.Attributes;
using Library.Net.Mvc.Controllers;

namespace Demo.Web.Controllers {

    public class PermissionController : BaseController {

        public ActionResult Index(long accountId) {
            if (accountId < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");

            var viewModel = new IndexViewModel {
                Pages = new Collection<PageViewModel> {
                    new PageViewModel { Name = "Principal", Controller = "Home", Action = "Index", Granted = true },

                    new PageViewModel { Name = "Sair", Controller = "Login", Action = "LogOff", Granted = true },
                                      
                    new PageViewModel { Name = "Contas", Controller = "Account", Action = "Index", Granted = true },
                    new PageViewModel { Name = "Editar conta", Controller = "Account", Action = "Edit", Granted = true },
                    new PageViewModel { Name = "Criar conta", Controller = "Account", Action = "ChangePassword", Granted = true },
                                      
                    new PageViewModel { Name = "Páginas", Controller = "Page", Action = "Index", Granted = true },
                    new PageViewModel { Name = "Criar página", Controller = "Page", Action = "Create", Granted = false },
                    new PageViewModel { Name = "Editar página", Controller = "Page", Action = "Edit", Granted = false },
                    new PageViewModel { Name = "Deletar página", Controller = "Page", Action = "Delete", Granted = false },
                                      
                    new PageViewModel { Name = "Permissões", Controller = "Permission", Action = "Index", Granted = true }
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Permission")]
        [Button("grant")]
        public ActionResult Grant(long accountId, long grant) {
            if (accountId < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");
            if (grant < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");

            try {
                //TODO: Conceder acesso.

                Success("Permissão concedida com sucesso!");
            }
            catch {
                Error("Erro ao conceder a permissão!");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Permission")]
        [Button("deny")]
        public ActionResult Deny(long accountId, long deny) {
            if (accountId < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");
            if (deny < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");

            try {
                //TODO: Negar acesso.

                Success("Permissão negada com sucesso!");
            }
            catch {
                Error("Erro ao negar a permissão!");
            }

            return RedirectToAction("Index");
        }
    }
}
