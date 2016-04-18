using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public class Repository
    {
        public const int MinPileCount = 2;
        public const int MaxPileCount = 5;

        public const int MinItemsInPile = 3;
        public const int MaxItemsInPile = 6;

        public static readonly Repository Instance = new Repository();

        public Dictionary<string, GameState> ActiveGames = new Dictionary<string, GameState>();

        public GameState NewGame()
        {
            string newid = Guid.NewGuid().ToString();
            var res = new GameState
            {
                GameId = newid,
                PlayerOnTheMove = 1,
                PlayerWins = 0,
            };

            var random = new Random();
            res.Piles = new int[random.Next(MinPileCount, MaxPileCount + 1)];
            for (int i = 0; i < res.Piles.Length; i++)
            {
                res.Piles[i] = random.Next(MinItemsInPile, MaxItemsInPile + 1);
            }

            ActiveGames[newid] = res;
            return res;
        }

        public GameState Move(string gameid, int pile, int count)
        {
            if (gameid == null || !ActiveGames.ContainsKey(gameid)) return new GameState { ErrorMessage = "Game expired" };
            var state = ActiveGames[gameid];
            if (pile < 0 || pile >= state.Piles.Length) return new GameState { ErrorMessage = "Invalid pile" };
            if (count < 0 || count > state.Piles[pile]) return new GameState { ErrorMessage = "Invalid count" };
            state.Piles[pile] -= count;

            if (state.Piles.All(x => x == 0))
            {
                state.PlayerWins = state.PlayerOnTheMove;
            }
            if (state.PlayerWins == 0)
            {
                state.PlayerOnTheMove = state.PlayerOnTheMove == 1 ? 2 : 1;
            }
            return state;
        }
    }
}
