using GamesOnline.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace GamesOnline.Tests.Models
{
    [Binding]
    public class NimHotSeatSteps
    {
        private Nim _currentGame;
        private GameState _currentGameState;

        [Given(@"Piles")]
        public void GivenPiles(Table table)
        {
            var piles = table.Rows[0].Values.ToList().Select(uint.Parse).ToArray();
            _currentGame = new Nim(Player.One, piles);
        }
        
        [When(@"New game is started")]
        public void WhenNewGameIsStarted()
        {
            var piles = Nim.CreateRandomPiles();
            _currentGameState = Repository.Instance.NewGame("g1", piles, "p1", "p2");
        }
        
        [When(@"Take all coins from the last pile")]
        public void WhenTakeAllCoinsFromTheLastPile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The piles count is more than (.*)")]
        public void ThenThePilesCountIsMoreThan(int pilesCount)
        {
            Assert.IsNotNull(_currentGameState);
            Assert.IsTrue(_currentGameState.Piles.Length > pilesCount);
        }
        
        [Then(@"Player (.*) is on the move")]
        public void ThenPlayerIsOnTheMove(int playerNumber)
        {
            Assert.IsNotNull(_currentGame);
            Assert.Equals(_currentGame.ActivePlayer,(Player)playerNumber);
        }
        
        [Then(@"All piles have more coins than (.*)")]
        public void ThenAllPilesHaveMoreCoinsThan(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"An exception is thrown")]
        public void ThenAnExceptionIsThrown()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Player (.*) wins")]
        public void ThenPlayerWins(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
