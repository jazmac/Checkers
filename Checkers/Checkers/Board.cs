﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Board
    {
        private string[,] board1;
        public const int dimensions = 8; // 8*8 game board

        private Pieces checker;
        private Moves move;

        public Board() //The "assets" used to construct the game board.
        {
            checker = new Pieces();
            move = new Moves();
            board1 = new string[dimensions, dimensions];
            BoardHoriz = "+---";
            BoardVert = "| ";
        }
        public string BoardHoriz { get; set; }
        public string BoardVert{ get; set; }

        public void displayBoard()
        {
            //while(!move.Close)
            //{
                Console.Clear(); //Clears the console screen after each move.
                Console.WriteLine("    A   B   C   D   E   F   G   H");
            
                for(int i = 0; i < dimensions; i++)
                {
                    Console.Write("  "); //Space between board and left console window.
                    for (int j = 0; j < dimensions; j++)
                    {
                        Console.Write(BoardHoriz);
                    }

                    Console.Write("+\n"); //"+" at end of each row to complete the board.

                    for(int k = 0; k < dimensions; k++)
                    {
                    if (k == 0)
                        Console.Write(i + " ");
                        Console.Write(BoardVert + Pieces.checkers[i, k] + " "); //Spacing around pieces on board.
                    }
                    Console.Write("|\n");
                
                }

            Console.Write("  ");
            for (int k = 0; k < dimensions; k++) //Final row to complete board.
            {
                Console.Write(BoardHoriz);
            }

            Console.Write("+\n\n");
            //}
            Console.ReadKey();
        }

    }
}