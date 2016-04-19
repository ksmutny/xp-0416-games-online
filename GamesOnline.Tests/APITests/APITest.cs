using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamesOnline.Tests.APITests
{
    public class APITest
    {
        [Fact]
        public void NewGameAllEmpty()
        {
            var gs = new GameState {
                GameId = "42",
                Piles = new int[] { 2, 3, 4, 2 },
                PlayerOnTheMove = string.Empty,
                PlayerName1 = string.Empty,
                PlayerName2 = string.Empty                
            };
            var repoMock = new RepositoryMock(gs);
            var controller = new GamesOnline.Controllers.NimController(repoMock);
            var resModel = controller.NewGame(string.Empty, string.Empty, string.Empty);

            Assert.True(resModel.Data.GetType() == typeof(GameState));

            var returnGs = (GameState)resModel.Data;

            Assert.Equal(returnGs.GameId, gs.GameId);
            Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
            Assert.Equal(returnGs.PlayerName1, gs.PlayerName1);
            Assert.Equal(returnGs.PlayerName2, gs.PlayerName2);
            Assert.True(returnGs.Piles.Length == gs.Piles.Length);            

            for (int i = 0; i < returnGs.Piles.Length; i++)
            {
                Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
            }
        }

        [Fact]
        public void NewGameEmptyPlayerNames()
        {
            var gs = new GameState
            {
                GameId = "42",
                Piles = new int[] { 2, 3, 4, 2 },
                PlayerOnTheMove = string.Empty,
                PlayerName1 = string.Empty,
                PlayerName2 = string.Empty
            };
            var repoMock = new RepositoryMock(gs);
            var controller = new GamesOnline.Controllers.NimController(repoMock);
            var resModel = controller.NewGame("MyGame", string.Empty, string.Empty);

            Assert.True(resModel.Data.GetType() == typeof(GameState));

            var returnGs = (GameState)resModel.Data;

            Assert.Equal(returnGs.GameId, gs.GameId);
            Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
            Assert.Equal(returnGs.PlayerName1, gs.PlayerName1);
            Assert.Equal(returnGs.PlayerName2, gs.PlayerName2);
            Assert.True(returnGs.Piles.Length == gs.Piles.Length);

            for (int i = 0; i < returnGs.Piles.Length; i++)
            {
                Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
            }
        }

        [Fact]
        public void NewGameEmptySecondPlayerName()
        {
            var gs = new GameState
            {
                GameId = "42",
                Piles = new int[] { 2, 3, 4, 2 },
                PlayerOnTheMove = "Player1",
                PlayerName1 = "Player1",
                PlayerName2 = string.Empty
            };
            var repoMock = new RepositoryMock(gs);
            var controller = new GamesOnline.Controllers.NimController(repoMock);
            var resModel = controller.NewGame("MyGame", gs.PlayerName1, string.Empty);

            Assert.True(resModel.Data.GetType() == typeof(GameState));

            var returnGs = (GameState)resModel.Data;

            Assert.Equal(returnGs.GameId, gs.GameId);
            Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
            Assert.Equal(returnGs.PlayerName1, gs.PlayerName1);
            Assert.Equal(returnGs.PlayerName2, gs.PlayerName2);
            Assert.True(returnGs.Piles.Length == gs.Piles.Length);

            for (int i = 0; i < returnGs.Piles.Length; i++)
            {
                Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
            }
        }

        [Fact]
        public void MoveTest()
        {
            var gs = new GameState
            {
                GameId = "42",
                Piles = new int[] { 2, 3, 4, 2 },
                PlayerOnTheMove = "Player1",
                PlayerName1 = "Player1",
                PlayerName2 = string.Empty
            };
            var repoMock = new RepositoryMock(gs);
            var controller = new GamesOnline.Controllers.NimController(repoMock);
            var resModel = controller.Move(gs.GameId, 0, 1, "Player1");

            Assert.True(resModel.Data.GetType() == typeof(GameState));

            var returnGs = (GameState)resModel.Data;

            Assert.Equal(returnGs.GameId, gs.GameId);
            Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
            Assert.Equal(returnGs.PlayerName1, gs.PlayerName1);
            Assert.Equal(returnGs.PlayerName2, gs.PlayerName2);
            Assert.True(returnGs.Piles.Length == gs.Piles.Length);

            for (int i = 0; i < returnGs.Piles.Length; i++)
            {
                Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
            }
        }
    }
}
