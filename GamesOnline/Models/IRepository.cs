using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOnline.Models
{
    public interface IRepository
    {
        GameState NewGame(int[] pilesCountArray);
        GameState Move(string gameid, int pile, int count);
    }
}
