using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public class GameState
    {
        public string GameId;

        public Nim Nim;
        public uint[] Piles => Nim.Piles;
        public string PlayerOnTheMove => this.GetPlayerName(this.Nim.ActivePlayer);
        public string PlayerWins => this.Nim.IsOver ? this.GetPlayerName(this.Nim.NextPlayer) : string.Empty;
        public string ErrorMessage;
        public string PlayerName1;
        public string PlayerName2;
        public bool IsGameOver { get; internal set; }

        private string GetPlayerName(Player nextPlayer)
        {
            var result = nextPlayer == Player.One ? this.PlayerName1 : this.PlayerName2;
            return result;
        }
    }
}