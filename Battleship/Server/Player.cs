﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Player
    {
        public Board board;

        public Player(int boardSize)
        {
            board = new Board(boardSize);
        }
    }
}
