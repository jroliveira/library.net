namespace appsimple.mvc.bootstrap.Lib {

    public static class Alerts {

        // ReSharper disable InconsistentNaming
        public const string SUCCESS = "success";
        public const string ATTENTION = "attention";
        public const string ERROR = "error";
        public const string INFORMATION = "info";

        public static string[] ALL {
            get { return new[] { SUCCESS, ATTENTION, INFORMATION, ERROR }; }
        }
        // ReSharper restore InconsistentNaming
    }
}
