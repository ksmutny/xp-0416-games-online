﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOnline.Models
{
    public interface IRepository
    {
        GameState NewGame(string gameName, int[] pilesCountArray, string player1, string player2);
        GameState Move(string gameid, string playerName, int pile, int count);
    }
}