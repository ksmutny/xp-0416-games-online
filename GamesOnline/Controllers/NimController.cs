using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamesOnline.Controllers
{
    public class NimController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewGame()
        {
            return Json(Repository.Instance.NewGame(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Move(string id, int pile, int count )
        {
            return Json(Repository.Instance.Move(id, pile, count), JsonRequestBehavior.DenyGet);
        }
    }
}