using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesOnline.Controllers
{
    public class NimController : Controller
    {
        public ActionResult Index(string id)
        {
            int model = 0;
            return View(model);
        }


        public ActionResult Move(string id, int pile, int count )
        {
            int model = 0;
            return Json(model, JsonRequestBehavior.DenyGet);
        }
    }
}