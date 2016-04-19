using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public enum Player { One, Two }

    public class Nim
    {
        public uint[] Piles;
        public readonly Player ActivePlayer;

        public Nim(Player player, params uint[] piles)
        {
            if (piles?.Length <= 1) throw new ArgumentException();
            this.Piles = piles;
            this.ActivePlayer = player;
        }

        public bool IsOver => Piles.All(x => x == 0);
    }
}