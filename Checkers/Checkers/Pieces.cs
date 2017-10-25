using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pieces
    {
        public const char Checker_symbol = 'O';
        public const char spaces = ' ';
        public static char[,] checkers;

        public Pieces()
        {
            checkers = new char[Board.dimensions, Board.dimensions];
            inPieces();
        }

        private void inPieces()
        {
            for(int i = 0; i < Board.dimensions; i++)
            {
                for (int j = 0; j < Board.dimensions; j++)
                {
                    if (i == 0 || i == 1 || i == Board.dimensions - 2 || i == Board.dimensions - 1)
                        checkers[i, j] = Checker_symbol;
                    else
                        checkers[i, j] = spaces;
                }
            }
        }

    }
}
