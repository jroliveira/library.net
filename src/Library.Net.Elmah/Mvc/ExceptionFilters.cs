namespace Library.Net.Elmah.Mvc {

    public static class ExceptionFilters {

        public static ExceptionFilterCollection Filters { get; private set; }

        static ExceptionFilters() {
            Filters = new ExceptionFilterCollection();
        }
    }
}