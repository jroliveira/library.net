using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Demo.Web.Lib.Validations;

namespace Demo.Web.Models.Page {

    public class CreateViewModel {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "Folha de Estilo")]
        public string CssClass { get; set; }

        [Display(Name = "Ação")]
        [RequiredIfPropertyEqualTo("IsRoot", false, ErrorMessage = "Campo obrigatório.")]
        public string Action { get; set; }

        [Display(Name = "Controlador")]
        [RequiredIfPropertyEqualTo("IsRoot", false, ErrorMessage = "Campo obrigatório.")]
        public string Controller { get; set; }

        [Display(Name = "Mostrar no Menu?")]
        public bool ShowInMenu { get; set; }

        [Display(Name = "É base?")]
        public bool IsRoot { get; set; }

        [Display(Name = "Base")]
        public int RootId { get; set; }

        public IList<RootViewModel> Roots { get; set; }

        public CreateViewModel() {
            Roots = new Collection<RootViewModel>();
        }

        public SelectList GetRoots() {
            Roots.Insert(0, new RootViewModel { Id = -1, Name = "Selecione um item." });

            return new SelectList(Roots, "Id", "Name", 0);
        }
    }
}