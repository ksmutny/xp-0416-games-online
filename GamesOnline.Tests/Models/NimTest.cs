using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamesOnline.Tests.Models
{
    public class NimTest
    {
        [Fact]
        public void ConstructorTest_ParamsArgs_2_args()
        {
            var state1 = new Nim(Player.One, 3, 4);
            Assert.True(new uint[] { 3, 4 }.SequenceEqual(state1.Piles));
        }

        [Fact]
        public void ConstructorTest_ParamsArgs_5_args()
        {
            var state2 = new Nim(Player.One, 3, 4, 5, 6, 7);
            Assert.True(new uint[] { 3, 4, 5, 6, 7 }.SequenceEqual(state2.Piles));
        }

        [Fact]
        public void ConstructorTest_ArrayArgs()
        {
            var state3 = new Nim(Player.One, new uint[] { 3, 4, 5, 6, 7 });
            Assert.True(new uint[] { 3, 4, 5, 6, 7 }.SequenceEqual(state3.Piles));
        }

        [Fact]
        public void ConstructorTest_Player()
        {
            var state = new Nim(Player.Two, new uint[] { 3, 4, 5, 6, 7 });
            Assert.Equal(Player.Two, state.ActivePlayer);
        }

        [Theory]
        [InlineData(new uint[] { })]
        [InlineData(new uint[] { 1 })]
        public void ConstructorTest_NoPiles(uint[] piles)
        {
            Assert.Throws<ArgumentException>(() => new Nim(Player.Two, piles));
        }

        [Theory]
        [InlineData(true, new uint[] {0,0,0 })]
        [InlineData(true, new uint[] {  0, 0 })]
        [InlineData(false, new uint[] { 3, 0, 0 })]
        [InlineData(false, new uint[] { 3, 5, 1 })]
        public void ConstructorTest_IsOver(bool expectedIsOver, uint[] piles)
        {
            var state = new Nim(Player.Two, piles);
            Assert.Equal(expectedIsOver, state.IsOver);
        }

        [Fact]
        public void ConstructorTest_TakeCoins()
        {
            var state = new Nim(Player.One, new uint[] { 3, 4 });
            var newState = state.TakeCoins(1, 2);
            Assert.True(new uint[] { 3, 2 }.SequenceEqual(newState.Piles));
            Assert.Equal(Player.Two, newState.ActivePlayer);
            Assert.False(newState.IsOver);
            Assert.True(new uint[] { 3, 4 }.SequenceEqual(state.Piles));
        }

        [Fact]
        public void ConstructorTest_TakeCoinsPlayerTwo()
        {
            var state = new Nim(Player.Two, new uint[] { 3, 4 });
            var newState = state.TakeCoins(1, 2);
            Assert.Equal(Player.One, newState.ActivePlayer);
        }

        [Fact]
        public void ConstructorTest_TakeCoinsInvalidPile()
        {
            var state = new Nim(Player.Two, new uint[] { 3, 4 });
            Assert.Throws<IndexOutOfRangeException>(() => state.TakeCoins(3, 2));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void ConstructorTest_TakeInvalidCoins(uint coins)
        {
            var state = new Nim(Player.Two, new uint[] { 3, 4 });
            Assert.Throws<ArgumentOutOfRangeException>(() => state.TakeCoins(1, coins));
        }
    }
}
