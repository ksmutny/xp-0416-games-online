using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GamesOnline.Tests.Models
{
    [Binding]
    public sealed class PokusSteps
    {
        /[Given(@"PokusTable")]
        public void GivenPokusTable(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                var a = table.Rows[i].Values.ToList().Select(int.Parse);
            }
            ScenarioContext.Current.Pending();
        }

        [Given(@"Player (.*) is on the move")]
        public void GivenPlayerIsOnTheMove(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Take (.*) coins from pile (.*)")]
        public void WhenTakeCoinsFromPile(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The piles are")]
        public void ThenThePilesAre(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
