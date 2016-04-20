using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamesOnline.Tests.Models
{
    public class AITests
    {
        [Fact]
        public void EvaluateTest()
        {
            var nim1 = new Nim(Player.One, 1, 2);
            Assert.Equal(1, nim1.Evaluate());

            var nim2 = new Nim(Player.One, 2, 2);
            Assert.Equal(0, nim2.Evaluate());
        }

        [Fact]
        public void AiTest()
        {
            var nim1 = new Nim(Player.One, 1, 2);
            var ai1 = nim1.AiMove();
            Assert.True(ai1.Piles.SequenceEqual(new uint[] { 1, 1 }));
        }

        [Fact]
        public void AiLoseTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var nim1 = new Nim(Player.One, 3, 4, 2, 5);
                var ai1 = nim1.AiMove();
                int sum = 0;
                if (ai1.Piles[0] != 3) sum++;
                if (ai1.Piles[1] != 4) sum++;
                if (ai1.Piles[2] != 2) sum++;
                if (ai1.Piles[3] != 5) sum++;
                Assert.Equal(1, sum);
                Assert.Equal(13, ai1.Piles.Select(x => (int)x).Sum());
            }
        }
    }
}
