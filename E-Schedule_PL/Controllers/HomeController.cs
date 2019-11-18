using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Schedule_BLL;

namespace E_Schedule_PL.Controllers
{
    public class HomeController : Controller
    {
        IBLL bll;

        public HomeController(IBLL bll)
        {
            this.bll = bll;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
