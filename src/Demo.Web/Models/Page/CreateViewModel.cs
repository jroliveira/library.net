using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Models.Page {

    public class CreateViewModel {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Url { get; set; }
    }
}