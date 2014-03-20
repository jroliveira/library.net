using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Demo.Web.Models.Account {

    public class EditViewModel {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Remote("CheckUserEmailNonexistence", "Account")]
        [Email(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }
    }
}