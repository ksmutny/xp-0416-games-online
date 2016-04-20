using GamesOnline.Models;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace GamesOnline.Tests
{
    [Binding]
    public class NimAISteps
    {
        private Nim _currentGame;

        [Given(@"Piles And Computer is on the move")]
        public void GivenPiles(Table table)
        {
            var piles = table.Rows[0].Values.ToList().Select(uint.Parse).ToArray();
            var state = new Nim(Player.Two, piles.Select(x => (uint)x).ToArray());
            this._currentGame = state;
        }

        [When(@"Take all coins from the last pile")]
        public void WhenTakeAllCoinsFromTheLastPile()
        {
            uint lastPile = (uint)_currentGame.Piles.Count() - 1;
            int coins = (int)_currentGame.Piles[lastPile];
            _currentGame.TakeCoins(coins, lastPile);
        }

        [Then(@"Computer wins")]
        public void ThenComputerWins()
        {
            var computerWins =_currentGame.IsOver && _currentGame.ActivePlayer == Player.Two;
            Assert.Equal(true, computerWins);
        }


        //[Given(@"Computer is on the move")]
        //public void GivenComputerIsOnTheMove()
        //{


        //    var piles = new uint[] { 5, 2, 5 };

        //    var state = repo.NewAIGame("test")

        //    Assert.Equal(piles, state.Piles);

        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"State of game before move is LOOSING")]
        //public void GivenStateOfGameBeforeMoveIsLOOSING()
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Given(@"State of game before move is WINNING")]
        //public void GivenStateOfGameBeforeMoveIsWINNING()
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[When(@"Computer makes move")]
        //public void WhenComputerMakesMove()
        //{
        //    ScenarioContext.Current.Pending();
        //}
        

        
        //[Then(@"after move state of game is WINNING")]
        //public void ThenAfterMoveStateOfGameIsWINNING()
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Then(@"The piles are")]
        //public void ThenThePilesAre(Table table)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Then(@"after move state of game is LOOSING")]
        //public void ThenAfterMoveStateOfGameIsLOOSING()
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        //[Then(@"Count of coins of any pile is less by (.*)")]
        //public void ThenCountOfCoinsOfAnyPileIsLessBy(int p0)
        //{
        //    ScenarioContext.Current.Pending();
        //}
    }
}
