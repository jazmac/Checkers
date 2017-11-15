using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Moves : Pieces
    {
        private int cooX;
        private int cooY;
        private int desX;
        private int desY;

        //Array to store players moves.
        int[,] cooArray = new int[10000, 10000];

  
        
        


        public bool Close { get; set; }

        public void Player1MovePiece()
        {
            Player1Input();

            if (!Close)
                reCheckers1();
        }

        public void Player2MovePiece()
        {
            Player2Input();

            if (!Close)
                reCheckers2();
        }

        private void Player1Input()
        {
            //accepts and checks if user input is valid.
            Console.WriteLine("Player 1's turn (X)");
            Console.WriteLine("Enter X coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out cooX));                
            cooArray[0,0] = cooX;
                Console.WriteLine("X coordinate = {0}", cooArray[0, 0]);
           


            if (!Close) //if passed initial check, requests second user input.
            {
                Console.WriteLine("Enter Y coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out cooY));
                cooArray[0,0] = cooY;
                Console.WriteLine("Y coordinate = {0}", cooArray[0, 0]);

            }

            if (!Close) //requests checker destination coordinates.
            {
                Console.WriteLine("Enter destination X coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out desX));
                if (desX != cooX + 1)
                {
                    Console.WriteLine("This is not a valid move");
                    cooX = cooY = desX = desY = 0;
                    Player1Input();
                }

                

            }

            if (!Close)
            {
                Console.WriteLine("Enter destination Y coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out desY));
                if (desY == cooY)
                {
                    Console.WriteLine("This is not a valid move");
                    cooX = cooY = desX = desY = 0;
                    Player1Input();
                }

           
            }
        }

        private void Player2Input()
        {
            //accepts and checks if user input is valid.
            Console.WriteLine("Player 2's turn (O)");
            Console.WriteLine("Enter X coordinate");
            Close = validationcheck(int.TryParse(Console.ReadLine(), out cooX));
            cooArray[0, 0] = cooX;
            Console.WriteLine("X coordinate = {0}", cooArray[0, 0]);



            if (!Close) //if passed initial check, requests second user input.
            {
                Console.WriteLine("Enter Y coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out cooY));
                cooArray[0, 0] = cooY;
                Console.WriteLine("Y coordinate = {0}", cooArray[0, 0]);

            }

            if (!Close) //requests checker destination coordinates.
            {
                Console.WriteLine("Enter destination X coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out desX));
                if (desX != cooX - 1)
                {
                    Console.WriteLine("This is not a valid move");
                    cooX = cooY = desX = desY = 0;
                    Player2Input();
                }

            }

            if (!Close)
            {
                Console.WriteLine("Enter destination Y coordinate");
                Close = validationcheck(int.TryParse(Console.ReadLine(), out desY));
                if (desY == cooY)
                {
                    Console.WriteLine("This is not a valid move");
                    cooX = cooY= desX = desY = 0;                 
                    Player2Input();
                }

            }
        }

        private bool validationcheck(bool parsed) //Checks if the values input are within board dimensions.
        {
            bool error = false;
            /*
            if (!parsed)
                error = true;
            else if (cooX < 0 || cooY < 0 || desX < 0 || desY < 0)
                error = true;
            else if (cooX > Board.dimensions - 1 || cooY > Board.dimensions - 1 || desX > Board.dimensions - 1 || desY > Board.dimensions - 1)
                error = true;
            
            else if (desX == cooX && desY == cooY)
                error = true;


            if (error)
            {
                Console.WriteLine("This is not a valid input.");
                Player1Input();
            }
            */

            return error;

        }




        private void reCheckers1()
        {

            checkers[desX, desY] = checkers[cooX, cooY]; //moves checkers piece from original position to new destination.

            if (desX == 0)
            {
                checkers[desX, desY] = King_symbol;
            }

            checkers[cooX, cooY] = spaces; //sets previous checker position to blank. 
            cooX = cooY = desX = desY = 0;

        }

        private void reCheckers2()
        {

            checkers[desX, desY] = checkers[cooX, cooY]; //moves checkers piece from original position to new destination.

            if (desX == 7)
            {
                checkers[desX, desY] = King_symbol;
            }

            checkers[cooX, cooY] = spaces; //sets previous checker position to blank.   

        }




    }





}


