namespace Demo.Web.Models.Permission {

    public class PageViewModel {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool Granted { get; set; }

        public string GetText() {
            return Granted ? "Sim" : "Não";
        }

        public string GetTextColor() {
            return Granted ? "text-success" : "text-danger";
        }

        public string GetIconButton() {
            return Granted ? "glyphicon glyphicon-ok-sign" : "glyphicon glyphicon-remove-sign";
        }

        public string GetColorButton() {
            return Granted ? "btn btn-success" : "btn btn-danger";
        }

        public string GetNameButton() {
            return Granted ? "grant" : "deny";
        }
    }
}