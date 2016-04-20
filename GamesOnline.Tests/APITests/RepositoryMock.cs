using GamesOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOnline.Tests.APITests
{
    public class RepositoryMock : IRepository
    {
        private GameState _state;

        public RepositoryMock()
        { }

        public RepositoryMock(GameState mockState)
        {
            _state = mockState;
        }

        public GameState NewGame(string gameName, uint[] pilesCountArray, string player1, string player2)
        {
            return _state;
        }

        public GameState NewAIGame(string gameName, uint[] pilesCountArray, string player1)
        {
            return _state;
        }

        public GameState Move(string gameid, string playerName, int pile, int count)
        {
            return _state;
        }        
    }
}
