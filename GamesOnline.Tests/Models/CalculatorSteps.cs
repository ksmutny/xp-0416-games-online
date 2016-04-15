using GamesOnline.Models;
using TechTalk.SpecFlow;
using Xunit;

namespace WebApplication1.Tests
{
    [Binding]
    class CalculatorSteps
    {
        private int actualResult;

        [When(@"I add numbers (\d+) and (\d+)")]
        public void WhenIAddNumbers(int a, int b)
        {
            actualResult = Calculator.Add(a, b);
        }

        [Then(@"the result is (\d+)")]
        public void ThenTheResultIs(int expectedResult)
        {
            Assert.Equal(expectedResult, actualResult);
        }
    }
}