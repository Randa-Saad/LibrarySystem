using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystemV1.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("WrongData");
        }
        public ActionResult Oops()
        {
            return RedirectToAction("WrongData");
        }
    }
}