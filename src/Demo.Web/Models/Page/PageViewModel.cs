namespace Demo.Web.Models.Page {

    public class PageViewModel {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShowInMenu { get; set; }

        public string GetShowInMenu() {
            return ShowInMenu ? "Sim" : "Não";
        }
    }
}