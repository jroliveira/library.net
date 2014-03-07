using System.Web.Mvc;

namespace Demo.Web.Controllers {

    [Authorize]
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }
    }
}
