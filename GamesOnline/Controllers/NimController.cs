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

        public JsonResult NewGame(string gameName, string player1, string player2)
        {
            var randomPiles = CreateRandomPiles();
            return Json(_repo.NewGame(gameName, randomPiles, player1, player2), JsonRequestBehavior.AllowGet);
        }

        public JsonResult NewGameAI(string gameName, string player1)
        {
            var randomPiles = CreateRandomPiles();
            return Json(_repo.NewAIGame(gameName, randomPiles, player1), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Move(string id, int pile, int count, string playerName)
        {
            try
            {
                var res = _repo.Move(id, playerName, pile, count);
                return Json(res, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
            }

            return Json(string.Empty, JsonRequestBehavior.DenyGet);            
        }

        private uint[] CreateRandomPiles()
        {
            var random = new Random();

            var result = new uint[random.Next(MinPileCount, MaxPileCount + 1)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (uint)random.Next(MinItemsInPile, MaxItemsInPile + 1);
            }

            return result;
        }
    }
}