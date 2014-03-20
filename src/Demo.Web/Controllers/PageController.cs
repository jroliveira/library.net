﻿using System.Web.Mvc;
using Demo.Web.Models.Page;
using Library.Net.Mvc.Controllers;

namespace Demo.Web.Controllers {

    public class PageController : BaseController {
        
        [HttpGet]
        public ActionResult Index() {
            var viewModel = new IndexViewModel();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
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
        public ActionResult Edit(object id) {
            var viewModel = new EditViewModel();

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
        public ActionResult Delete(object id) {
            //TODO: Deletar página.

            return RedirectToAction("Index");
        }
    }
}
