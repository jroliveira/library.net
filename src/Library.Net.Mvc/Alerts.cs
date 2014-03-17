namespace Library.Net.Mvc {

    public static class Alerts {

        // ReSharper disable InconsistentNaming
        public const string SUCCESS = "success";
        public const string WARNING = "warning";
        public const string DANGER = "danger";
        public const string INFORMATION = "info";

        public static string[] ALL {
            get { return new[] { SUCCESS, WARNING, INFORMATION, DANGER }; }
        }
        // ReSharper restore InconsistentNaming
    }
}
