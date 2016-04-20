using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public class Repository : IRepository
    {
        public static readonly Repository Instance = new Repository();

        public Dictionary<string, GameState> ActiveGames = new Dictionary<string, GameState>();

        public GameState NewGame(string gameName, uint[] pilesCountArray, string player1, string player2)
        {
            string newid = gameName;

            var res = new GameState
            {
                Nim = new Nim(Player.One, pilesCountArray.Select(x => (uint)x ).ToArray()),
                GameId = newid,
                //PlayerOnTheMove = player1,
                //PlayerWins = string.Empty,
                PlayerName1 = player1,
                PlayerName2 = player2,
                IsGameOver = false,
            };

            ActiveGames[newid] = res;
            return res;
        }

        public GameState Move(string gameid, string playerName, int pile, int count)
        {
            if (gameid == null || !ActiveGames.ContainsKey(gameid)) return new GameState { ErrorMessage = "Game expired" };
            var state = ActiveGames[gameid];
            if (pile < 0 || pile >= state.Piles.Length) return new GameState { ErrorMessage = "Neplatný tah" };
            if (count < 0 || count > state.Piles[pile]) return new GameState { ErrorMessage = "Neplatný počet" };
            state.Piles[pile] -= count;

            if (state.Piles.All(x => x == 0))
            {
                state.IsGameOver = true;
                state.PlayerWins = state.PlayerOnTheMove;
                return state;
            }

            state.Nim = state.Nim.TakeCoins(pile, (uint)count);

            return state;
        }
    }
}
