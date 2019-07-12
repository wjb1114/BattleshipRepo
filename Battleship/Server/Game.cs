using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Game
    {
        public Player playerOne;
        public Player playerTwo;

        public Game(int boardSize)
        {
            playerOne = new Player(boardSize);
            playerTwo = new Player(boardSize);
        }
    }
}
