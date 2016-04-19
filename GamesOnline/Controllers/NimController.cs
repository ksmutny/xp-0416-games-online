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
        public const int MinPileCount = 2;
        public const int MaxPileCount = 5;

        public const int MinItemsInPile = 3;
        public const int MaxItemsInPile = 6;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewGame()
        {
            var randomPiles = CreateRandomPiles();
            return Json(Repository.Instance.NewGame(randomPiles), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Move(string id, int pile, int count )
        {
            return Json(Repository.Instance.Move(id, pile, count), JsonRequestBehavior.DenyGet);
        }

        private int[] CreateRandomPiles()
        {
            var random = new Random();

            var result = new int[random.Next(MinPileCount, MaxPileCount + 1)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.Next(MinItemsInPile, MaxItemsInPile + 1);
            }

            return result;
        }
    }
}