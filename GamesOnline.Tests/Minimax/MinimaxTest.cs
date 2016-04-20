using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using GamesOnline.AI;

namespace GamesOnline.Tests.Minimax
{
    public class MinimaxTest
    {
        private double Evaluate(int state)
        {
            return state;
        }

        private List<int> Generate(int state)
        {
            var result = new List<int>
            {
                state % 7,
                state * 3 % 13,
                state * 5 % 17
            };

            return result;
        }

        [Fact]
        public void EvaluateTest_Simple()
        {
            var state = 5;
            var minimax = new GamesOnline.AI.Minimax<int>(1, Evaluate, Generate);
            var nextState = minimax.NextState(state);

            Assert.Equal(8, nextState);
        }

        [Fact]
        public void EvaluateTest_SecondLevel()
        {
            var state = 5;
            var minimax = new GamesOnline.AI.Minimax<int>(2, Evaluate, Generate);
            var nextState = minimax.NextState(state);

            Assert.Equal(5, nextState);
        }

    }
}
