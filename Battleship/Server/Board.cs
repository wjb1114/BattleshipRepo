using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Board
    {
        // O = miss
        // X = hit
        // " " = empty
        // S = occupied
        char[,] boardState;
        Ship destroyer;
        Ship submarine;
        Ship battleship;
        Ship carrier;

        public Board(int size)
        {
            boardState = new char[size,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    boardState[i, j] = ' ';
                }
            }
            destroyer = new Ship("Destroyer", 2);
            submarine = new Ship("Submarine", 3);
            battleship = new Ship("Battleship", 4);
            carrier = new Ship("Aircraft Carrier", 5);
        }

        public string GetBoardState()
        {
            string boardOutput = "    |";
            for (int i = 0; i < boardState.GetLength(1); i++)
            {
                string cell = "";
                cell += (i + 1);
                while(cell.Length < 4)
                {
                    cell += " ";
                }
                boardOutput += (cell + "|");
            }
            boardOutput += "\n";
            for (int i = 0; i < boardState.GetLength(0); i++)
            {
                for (int j = 0; j < boardState.GetLength(1) + 1; j++)
                {
                    boardOutput += "_____";
                }
                string identifier = "";
                identifier += (i + 1);
                while (identifier.Length < 4)
                {
                    identifier += " ";
                }
                boardOutput += "\n" + identifier + "|";
                for (int j = 0; j < boardState.GetLength(1); j++)
                {
                    string cell = "";
                    cell += boardState[j, i];
                    while (cell.Length < 4)
                    {
                        cell += " ";
                    }
                    boardOutput += (cell + "|");

                }
                boardOutput += "\n";
            }
            for (int i = 0; i < boardState.GetLength(1) + 1; i++)
            {
                boardOutput += "_____";
            }

            return boardOutput;
        }
    }
}
