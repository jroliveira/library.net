using System.Web.Mvc;

namespace Library.Net.Elmah.Mvc {

    public class ElmahController : Controller {

        [ElmahUsers]
        public ActionResult Index() {
            return new ElmahActionResult();
        }

        [ElmahUsers]
        public ActionResult Stylesheet() {
            return new ElmahActionResult("stylesheet");
        }

        [ElmahUsers]
        public ActionResult Rss() {
            return new ElmahActionResult("rss");
        }

        [ElmahUsers]
        public ActionResult DigestRss() {
            return new ElmahActionResult("digestrss");
        }

        [ElmahUsers]
        public ActionResult About() {
            return new ElmahActionResult("about");
        }

        [ElmahUsers]
        public ActionResult Detail() {
            return new ElmahActionResult("detail");
        }

        [ElmahUsers]
        public ActionResult Download() {
            return new ElmahActionResult("download");
        }

        [ElmahUsers]
        public ActionResult Json() {
            return new ElmahActionResult("json");
        }

        [ElmahUsers]
        public ActionResult Xml() {
            return new ElmahActionResult("xml");
        }
    }
}