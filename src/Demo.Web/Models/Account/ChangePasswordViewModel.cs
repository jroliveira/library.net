using System.ComponentModel.DataAnnotations;
using Demo.Web.Lib.Validations;

namespace Demo.Web.Models.Account {

    public class ChangePasswordViewModel : DefaultViewModel {

        [Display(Name = "Senha antiga")]
        [CompareOldPassword(ErrorMessage = "Senha não confere.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string OldPassword { get; set; }

        [Display(Name = "Nova senha")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmar senha")]
        [Compare("NewPassword", ErrorMessage = "Senha não confere.")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string ConfirmPassword { get; set; }

        protected override string MenuSelected {
            get { return "accountchangepassword"; }
        }
    }
}
