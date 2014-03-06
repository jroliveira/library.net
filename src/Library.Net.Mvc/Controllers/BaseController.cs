using System.Web.Mvc;

namespace Library.Net.Mvc.Controllers {

    public class BaseController : Controller {

        public void Attention(string message) {
            TempData.Clear();
            TempData.Add(Alerts.ATTENTION, message);
        }

        public void Success(string message) {
            TempData.Clear();
            TempData.Add(Alerts.SUCCESS, message);
        }

        public void Information(string message) {
            TempData.Clear();
            TempData.Add(Alerts.INFORMATION, message);
        }

        public void Error(string message) {
            TempData.Clear();
            TempData.Add(Alerts.ERROR, message);
        }
    }
}
