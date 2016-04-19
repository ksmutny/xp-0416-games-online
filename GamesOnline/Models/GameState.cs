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
        public string PlayerOnTheMove;
        public string PlayerWins;
        public string ErrorMessage;
        public string PlayerName1;
        public string PlayerName2;
        public bool IsGameOver { get; internal set; }
    }
}