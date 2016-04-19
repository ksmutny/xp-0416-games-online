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

        public GameState Move(string gameid, int pile, int count)
        {
            return _state;
        }

        public GameState NewGame(int[] pilesCountArray)
        {
            return _state;
        }
    }
}
