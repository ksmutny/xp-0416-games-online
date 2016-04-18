using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public class GameState
    {
        public string GameId;
        public int[] Piles;
        public int PlayerOnTheMove; // 1,2
        public int PlayerWins; // 1,2 (0 - nobody)
        public string ErrorMessage;
    }
}