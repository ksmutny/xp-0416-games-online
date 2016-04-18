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

            var state = repo.NewGame();
            Assert.True(state.Piles.Length >= Repository.MinPileCount && state.Piles.Length <= Repository.MaxPileCount);
            foreach (int countInPile in state.Piles)
            {
                Assert.True(countInPile >= Repository.MinItemsInPile && countInPile <= Repository.MaxItemsInPile);
            }
        }

        [Fact]
        public void MoveTest()
        {
            var repo = Repository.Instance;

            var gameId = repo.NewGame().GameId;

            var state1 = repo.Move(gameId, 1, 1);
            Assert.Equal(2, state1.PlayerOnTheMove);
            Assert.Equal(0, state1.PlayerWins);

            var state2 = repo.Move(gameId, 0, 1);
            Assert.Equal(1, state2.PlayerOnTheMove);
            Assert.Equal(0, state2.PlayerWins);
        }

        [Fact]
        public void FinishTest()
        {
            var repo = Repository.Instance;

            var state = repo.NewGame();
            while (state.PlayerWins == 0)
            {
                bool moved = false;
                for (int pile = 0; pile < state.Piles.Length; pile++)
                {
                    if (state.Piles[pile] != 0)
                    {
                        moved = true;
                        state = repo.Move(state.GameId, pile, state.Piles[pile]);
                        break;
                    }
                }
                if (moved) continue;
                Assert.False(moved, "PlayerWins not set");
            }

            Assert.True(state.Piles.All(x => x == 0));
            if (state.Piles.Length % 2 == 1) Assert.Equal(1, state.PlayerWins);
            if (state.Piles.Length % 2 == 0) Assert.Equal(2, state.PlayerWins);
        }
    }
}
