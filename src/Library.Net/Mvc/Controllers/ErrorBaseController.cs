using System.Net;
using System.Web.Mvc;

namespace Library.Net.Mvc.Controllers
{
    [AllowAnonymous]
    public class ErrorBaseController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public virtual ActionResult NotFound()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.NotFound;

            return View();
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public virtual ActionResult InternalServerError()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            return View();
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public virtual ActionResult Unauthorized()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            
            return View();
        }
    }
}
