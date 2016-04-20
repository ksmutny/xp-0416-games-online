using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public enum Player { One = 1, Two = 2 }

    public class Nim
    {
        public const int MinPileCount = 2;
        public const int MaxPileCount = 5;

        public const int MinItemsInPile = 3;
        public const int MaxItemsInPile = 6;

        public uint[] Piles;
        public readonly Player ActivePlayer;

        public Nim(Player player, params uint[] piles)
        {
            if (piles?.Length <= 1) throw new ArgumentException();
            this.Piles = piles;
            this.ActivePlayer = player;
        }

        public bool IsOver => Piles.All(x => x == 0);

        public Player NextPlayer => this.ActivePlayer == Player.One ? Player.Two : Player.One;

        public Nim TakeCoins(int pileIndex, uint coinsCount)
        {
            if (this.Piles[pileIndex] < coinsCount || coinsCount <= 0)
            {
                throw new ArgumentOutOfRangeException("Coins count must be more than zero and less than the count of coins on the specified pile!");
            }

            var newPiles = (uint[])this.Piles.Clone();
            newPiles[pileIndex] -= coinsCount;
            var newState = new Nim(this.NextPlayer, newPiles);
            return newState;
        }

        public static int[] CreateRandomPiles()
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