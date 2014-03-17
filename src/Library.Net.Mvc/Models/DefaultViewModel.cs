namespace Library.Net.Mvc.Models {

    public abstract class DefaultViewModel {

        protected abstract string MenuSelected { get; }

        public string IsActive(string menuItem) {
            return MenuSelected == menuItem ? "active" : "";
        }
    }
}