using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Demo.Web.Models.Account {

    public class ForgotPasswordViewModel {

        [Display(Name = "E-mail")]
        [Remote("CheckUserEmailExistence", "Account")]
        [Email(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }
    }
}