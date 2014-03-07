using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Demo.Web.Models.Account {

    public class CreateViewModel {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Remote("CheckUserEmailNonexistence", "Account")]
        [Email(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Password { get; set; }

        [Display(Name = "Confirmar senha")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Senha não confere.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string ConfirmPassword { get; set; }
    }
}