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
        public void NewGameTestEmptyName()
        {
            var gs = new GameState {
                GameId = "42",
                Piles = new int[] { 2,3,4,2 },
                PlayerOnTheMove = 1                
            };
            var repoMock = new RepositoryMock(gs);
            var controller = new GamesOnline.Controllers.NimController(repoMock);
            var resModel = controller.NewGame(string.Empty);

            Assert.True(resModel.Data.GetType() == typeof(GameState));

            var returnGs = (GameState)resModel.Data;

            Assert.Equal(returnGs.GameId, gs.GameId);
            Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
            Assert.True(returnGs.Piles.Length == gs.Piles.Length);

            for (int i = 0; i < returnGs.Piles.Length; i++)
            {
                Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
            }
        }

        [Fact]
        public void NewGameTestNotEmptyName()
        {
            var gs = new GameState
            {
                GameId = "42",
                Piles = new int[] { 2, 3, 4, 2 },
                PlayerOnTheMove = 1
            };
            var repoMock = new RepositoryMock(gs);
            var controller = new GamesOnline.Controllers.NimController(repoMock);
            var resModel = controller.NewGame("My game");

            Assert.True(resModel.Data.GetType() == typeof(GameState));

            var returnGs = (GameState)resModel.Data;

            Assert.Equal(returnGs.GameId, gs.GameId);
            Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
            Assert.True(returnGs.Piles.Length == gs.Piles.Length);

            for (int i = 0; i < returnGs.Piles.Length; i++)
            {
                Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
            }
        }

        //[Fact]
        //public void MoveTest()
        //{
        //    var gs = new GameState
        //    {
        //        GameId = "42",
        //        Piles = new int[] { 2, 3, 4, 2 },
        //        PlayerOnTheMove = 1
        //    };
        //    var repoMock = new RepositoryMock(gs);
        //    var controller = new GamesOnline.Controllers.NimController(repoMock);
        //    var resModel = controller.

        //    Assert.True(resModel.Data.GetType() == typeof(GameState));

        //    var returnGs = (GameState)resModel.Data;

        //    Assert.Equal(returnGs.GameId, gs.GameId);
        //    Assert.Equal(returnGs.PlayerOnTheMove, gs.PlayerOnTheMove);
        //    Assert.True(returnGs.Piles.Length == gs.Piles.Length);

        //    for (int i = 0; i < returnGs.Piles.Length; i++)
        //    {
        //        Assert.Equal(returnGs.Piles[i], gs.Piles[i]);
        //    }
        //}        
    }
}
