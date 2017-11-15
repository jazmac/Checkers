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
        public const char Checker_symbol2 = 'X';
        public const char King_symbol = 'K';
        public const char spaces = ' ';
        public static char[,] checkers;

        public Pieces()
        {
            checkers = new char[Board.dimensions, Board.dimensions];
            Player1Pieces();
            Player2Pieces();
        }

        private void Player1Pieces()
        {
           
             
            for (int i = 0; i < Board.dimensions; i++)
            {
                for (int m = 1; m < Board.dimensions; m += 2)
                {
                    if (i == 0 || i == 2) //places first and third row of upper checker pieces.
                        checkers[i, m] = Checker_symbol2;
                    else
                        checkers[i, m] = spaces;
                }


            }

            for (int i = 1; i < Board.dimensions; i++)
            {
                for (int k = 0; k < Board.dimensions; k += 2)
                {
                    if (i == 1)  //places second row of upper checker pieces.
                        checkers[i, k] = Checker_symbol2;
                    else
                        checkers[i, k] = spaces;
                }

            }

        }

        private void Player2Pieces()
        {

            for (int i = 3; i < Board.dimensions; i+=1)
            {
                for (int j = 0; j < Board.dimensions; j += 2)
                {
                    if (i == Board.dimensions - 3 || i == Board.dimensions - 1) //places first and third row of lower checker pieces.
                        checkers[i, j] = Checker_symbol;
                    else
                        checkers[i, j] = spaces;
                }


            }

            for (int i = 3; i < Board.dimensions; i++)
            {
                for (int t = 1; t < Board.dimensions; t += 2)
                {
                    if (i == Board.dimensions - 2)  //places second row of lower checker pieces.
                        checkers[i, t] = Checker_symbol;
                    else
                        checkers[i, t] = spaces;
                }

            }
            
        }
        

    }
}
