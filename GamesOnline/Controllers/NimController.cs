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

        private IRepository _repo;

        public NimController()
        {
            _repo = Repository.Instance;
        }

        public NimController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult NewGame(string gameName)
        {
            var randomPiles = CreateRandomPiles();            
            return Json(_repo.NewGame(randomPiles), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Move(string id, int pile, int count, int playerNumber)
        {
            return Json(_repo.Move(id, pile, count), JsonRequestBehavior.DenyGet);            
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