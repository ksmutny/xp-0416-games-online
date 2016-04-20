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

        // returns 0 when all xors are 0
        public int Evaluate()
        {
            for (int bit = 0; bit < 30; bit++)
            {
                int sum = Piles.Select(x => (x & (1 << bit)) != 0 ? 1 : 0).Sum() % 2;
                if (sum != 0) return 1;
            }
            return 0;
        }

        public IEnumerable<Nim> Generate()
        {
            for(int pile = 0; pile < Piles.Length; pile++)
            {
                for(int count = 1; count <= Piles[pile]; count++)
                {
                    yield return TakeCoins(pile, (uint)count);
                }
            }
        }

        public Nim AiMove()
        {
            var nextLevel = Generate();
            foreach(var item in nextLevel)
            {
                if (item.Evaluate() == 0) return item;
            }
            // AI win is not sure, make any move

            var notNullIndexes = new List<int>();
            for (int i = 0; i < Piles.Length; i++) if (Piles[i] > 0) notNullIndexes.Add(i);
            var rand = new Random();
            int removeFromPile = notNullIndexes[rand.Next(notNullIndexes.Count)];
            return TakeCoins(removeFromPile, 1);
        }
    }
}