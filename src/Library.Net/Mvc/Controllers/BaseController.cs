using System.Web.Mvc;

namespace Library.Net.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult Attention(string message, ActionResult actionResult)
        {
            TempData.Clear();
            TempData.Add(Alerts.WARNING, message);

            return actionResult;
        }

        public void Attention(string message)
        {
            Attention(message, null);
        }

        public ActionResult Success(string message, ActionResult actionResult)
        {
            TempData.Clear();
            TempData.Add(Alerts.SUCCESS, message);

            return actionResult;
        }

        public void Success(string message)
        {
            Success(message, null);
        }

        public ActionResult Information(string message, ActionResult actionResult)
        {
            TempData.Clear();
            TempData.Add(Alerts.INFORMATION, message);

            return actionResult;
        }

        public void Information(string message)
        {
            Information(message, null);
        }

        public ActionResult Error(string message, ActionResult actionResult)
        {
            TempData.Clear();
            TempData.Add(Alerts.DANGER, message);

            return actionResult;
        }

        public void Error(string message)
        {
            Error(message, null);
        }
    }
}
