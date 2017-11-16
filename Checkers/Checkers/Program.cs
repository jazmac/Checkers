using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board1 = new Board();
            int player = 1;
            bool inProgress = false;
            int cooX=-1;
            int cooY=-1;
            int Combo=-999;
            bool yCheck = false, xCheck = false, retry = false;
            while (board1.player1score < 12 && board1.player2score < 12)
            {
                board1.displayBoard();
                yCheck = false;
                xCheck = false;

                string symbol = "(X)";

                if (player == 2)
                {
                    symbol = "(O)";
                }

                while (xCheck == false || yCheck == false && inProgress != true)
                { 
                    //accepts and checks if user input is valid.
                    Console.WriteLine("Player {0}'s turn {1}", player, symbol);
                    Console.WriteLine("Enter X coordinate");
                    xCheck = int.TryParse(Console.ReadLine(), out cooX);
                    Console.WriteLine("X coordinate = {0}", cooX);
                    Console.WriteLine("Enter Y coordinate");
                    yCheck = int.TryParse(Console.ReadLine(), out cooY);
                    Console.WriteLine("Y coordinate = {0}", cooY);
                }

                if (xCheck && yCheck)
                {
                    Combo = board1.takeTurn(player, inProgress, cooX, cooY);
                }

                while (Combo==1)
                {
                    inProgress = true;
                    board1.takeTurn(player, inProgress, -1, -1);
                }

                if (Combo==0)
                {
                    if (player==1)
                    {
                        player = 2;
                    }
                    else
                    {
                        player = 1;
                    }
                }

                if (Combo==-1)
                {
                    retry = true;
                    Console.WriteLine("Invalid move, please try again.");
                }
            }
        }
    }
}
