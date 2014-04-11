using System.Collections.ObjectModel;
using System.Web;
using System.Web.Mvc;
using Demo.Web.Models.Page;
using Library.Net.Mvc.Controllers;

namespace Demo.Web.Controllers {

    public class PageController : BaseController {
        
        [HttpGet]
        public ActionResult Index() {
            var viewModel = new IndexViewModel { 
                Pages = new Collection<PageViewModel> {
                    new PageViewModel { Id = 1, Name = "Página", ShowInMenu = true },
                    new PageViewModel { Id = 1, Name = "Home", ShowInMenu = true },
                    new PageViewModel { Id = 1, Name = "Login", ShowInMenu = true },
                    new PageViewModel { Id = 1, Name = "Conta", ShowInMenu = true }
                }
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create() {
            var roots = new Collection<RootViewModel> {
                new RootViewModel { Id = 1, Name = "Cadastrar" }
            };

            return View(new CreateViewModel { Roots = roots });
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            try {
                //TODO: Criar página.

                Success("Página criada com sucesso!");
            }
            catch {
                Error("Erro ao criar a página!");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long id) {
            if (id < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");
            
            var roots = new Collection<RootViewModel> {
                new RootViewModel { Id = 1, Name = "Cadastrar" }
            };

            var viewModel = new EditViewModel { Roots = roots };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel viewModel) {
            if (!ModelState.IsValid) return Error("Existem campos para preencher.", View(viewModel));

            try {
                //TODO: Editar página.

                Success("Página editada com sucesso!");
            }
            catch {
                Error("Erro ao editar a página!");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(long id) {
            if (id < 1) throw new HttpException(404, "HTTP/1.1 404 Not Found");

            //TODO: Deletar página.

            return RedirectToAction("Index");
        }
    }
}
