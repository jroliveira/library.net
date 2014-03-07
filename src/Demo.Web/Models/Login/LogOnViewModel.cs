using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models.Login {

    public class LogOnViewModel {

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Password { get; set; }
    }
}