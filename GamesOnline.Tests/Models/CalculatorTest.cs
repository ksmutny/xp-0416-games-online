using GamesOnline.Models;
using Xunit;

namespace GamesOnline.Tests.Models
{
    public class CalculatorTest
    {
        [Fact]
        public void Add()
        {
            Assert.Equal(5, Calculator.Add(2, 3));
        }
    }
}