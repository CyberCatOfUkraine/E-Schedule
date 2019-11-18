using System.Web.Mvc;

namespace E_Schedule_PL.Controllers
{
    public class ErrorController :Controller
    {
        public ActionResult NotFound()
        {
           return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }
    }
}