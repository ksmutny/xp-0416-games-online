using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesOnline.Models
{
    public class Repository
    {
        public static readonly Repository Instance = new Repository();

        public Dictionary<string, GameState> ActiveGames = new Dictionary<string, GameState>();

        public GameState NewGame(string gameName, int[] pilesCountArray, string player1, string player2)
        {
            string newid = gameName;
            var res = new GameState
            {
                GameId = newid,
                PlayerOnTheMove = player1,
                PlayerWins = string.Empty,
                PlayerName1 = player1,
                PlayerName2 = player2,
                IsGameOver = false,
            };
            
            res.Piles = pilesCountArray; 

            ActiveGames[newid] = res;
            return res;
        }

        public GameState Move(string gameid, string playerName, int pile, int count)
        {
            if (gameid == null || !ActiveGames.ContainsKey(gameid)) return new GameState { ErrorMessage = "Game expired" };
            var state = ActiveGames[gameid];
            if (pile < 0 || pile >= state.Piles.Length) return new GameState { ErrorMessage = "Invalid pile" };
            if (count < 0 || count > state.Piles[pile]) return new GameState { ErrorMessage = "Invalid count" };
            state.Piles[pile] -= count;

            if (state.Piles.All(x => x == 0))
            {
                state.IsGameOver = true;
                state.PlayerWins = state.PlayerOnTheMove;
                return state;
            }

            state.PlayerOnTheMove = state.PlayerOnTheMove == state.PlayerName1 ? state.PlayerName2 : state.PlayerName1;

            return state;
        }
    }
}
