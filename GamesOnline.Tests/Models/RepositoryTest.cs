using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamesOnline.Tests.Models
{
    public class RepositoryTest
    {
        [Fact]
        public void NewGameTest()
        {
            var repo = Repository.Instance;

            var piles = new int[] { 5, 2, 5 };

            var state = repo.NewGame("test Hra", piles, "A", "B");

            Assert.Equal(piles, state.Piles);
        }

        [Fact]
        public void MoveTest()
        {
            var repo = Repository.Instance;

            var piles = new int[] { 5, 2, 5 };

            var gameId = repo.NewGame("test Hra", piles, "A", "B").GameId;

            //public GameState Move(string gameid, string playerName, int pile, int count)

            var state1 = repo.Move(gameId, "A", 1, 1);
            Assert.Equal("B", state1.PlayerOnTheMove);
            //Assert.Equal("", state1.PlayerWins);

            var state2 = repo.Move(gameId, "B", 0, 1);
            Assert.Equal("A", state2.PlayerOnTheMove);
            //Assert.Equal("B", state2.PlayerWins);
        }

        [Fact]
        public void FinishTest()
        {
            var repo = Repository.Instance;

            var piles = new int[] { 5, 2, 5 };

            var state = repo.NewGame("test Hra", piles, "A", "B");
            //while (state.PlayerWins == string.Empty)
            //{
            //    bool moved = false;
            //    for (int pile = 0; pile < state.Piles.Length; pile++)
            //    {
            //        if (state.Piles[pile] != 0)
            //        {
            //            moved = true;
            //            state = repo.Move(state.GameId, player, pile, state.Piles[pile]);
            //            break;
            //        }
            //    }
            //    if (moved) continue;
            //    Assert.False(moved, "PlayerWins not set");
            //}

            state = repo.Move(state.GameId, "A", 0,5);
            state = repo.Move(state.GameId, "B", 1, 2);
            state = repo.Move(state.GameId, "A", 2, 5);

            Assert.True(state.Piles.All(x => x == 0));
            if (state.Piles.Length % 2 == 1) Assert.Equal("A", state.PlayerWins);
            if (state.Piles.Length % 2 == 0) Assert.Equal("B", state.PlayerWins);
        }


    }
}
