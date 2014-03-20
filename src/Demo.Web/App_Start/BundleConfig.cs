using System.Web.Optimization;

namespace Demo.Web.App_Start {

    public class BundleConfig {

        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles) {

            bundles.Add(new ScriptBundle("~/js").Include(
                // query
                "~/Scripts/jquery-{version}.js",

                // query validate
                "~/Scripts/jquery.validate*",

                // twitter bootstrap
                "~/Content/bootstrap/js/bootstrap.js",

                // application
                "~/Script/script.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                // twitter bootstrap
                "~/Content/bootstrap/css/bootstrap.css",

                // application
                "~/Content/style.css"));
        }
    }
}