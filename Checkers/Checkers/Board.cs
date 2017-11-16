using System;

namespace ConsoleApp1
{
    public class Board
    {
        public const int dimensions = 8; // 8*8 game board
        Square[,] board1 = new Square[dimensions, dimensions];
        int saveX;
        int saveY;

        public int player1score = 0;
        public int player2score = 0;
        public Board() //The "assets" used to construct the game board.
        {
            reset();
        }
        public void reset()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board1[i, j] = new Square();
                    if (i % 2 == j % 2)
                    {
                        board1[i, j].status = 0;
                    }

                    else if (j < 3)
                    {
                        board1[i, j].status = 1;
                    }
                    else if (j > 4)
                    {
                        board1[i, j].status = 2;
                    }
                    else
                    {
                        board1[i, j].status = 0;
                    }
                }
            }
        }

        public void displayBoard()
        {
            Console.WriteLine("   0   1   2   3   4   5   6   7");
            Console.WriteLine(" +---+---+---+---+---+---+---+---+");
            for (int j = 0; j < dimensions; j++)
            {
                Console.Write(j);
                for (int i = 0; i < dimensions; i++)
                {
                    Console.Write("| " + board1[i, j].getIcon() + " ");
                }

                Console.Write("|\n"); //Space between board and left console window.
                Console.WriteLine(" +---+---+---+---+---+---+---+---+");
            }
        }

        public int takeTurn(int player, bool inProgress, int cooX, int cooY)
        {
            int desX;
            int desY;
            bool xCheck, yCheck;

            if (cooX==-1)
            {
                cooX = saveX;
                cooY = saveY;
            }
            
            if (inBounds(cooX, cooY))
            {
                if (validCoordinates(player, cooX, cooY))
                {
                    Console.WriteLine("Enter X destination");
                    xCheck = int.TryParse(Console.ReadLine(), out desX);
                    Console.WriteLine("X destination = {0}", desX);
                    Console.WriteLine("Enter Y destination");
                    yCheck = int.TryParse(Console.ReadLine(), out desY);
                    Console.WriteLine("Y destination = {0}", desY);

                    if (xCheck && yCheck)
                    {
                        if (inBounds(desX, desY))
                        {
                            if (validDestination(cooX, cooY, desX, desY, player, inProgress))
                            {
                                makeMove(cooX, cooY, desX, desY, player);
                                if (checkForLocalTakes(desX, desY))
                                {
                                    return 1; //this piece can still take.
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            else
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        private void makeMove(int cooX, int cooY, int desX, int desY, int player)
        {
            int xDistance = desX - cooX;
            board1[cooX, cooY].status = 0;
            
            int xChange = -1;
            int yChange = -1;

            if (desX > cooX)//left or right
            {
                xChange = 1;
            }

            if (desY > cooY)//left or right
            {
                yChange = 1;
            }

            if (xDistance > 1 || xDistance < -1)//not taking
            {
                board1[desX, desY].status = player;
                board1[desX, desY].king = board1[cooX, cooY].king;
            }
            else//is taking
            {
                board1[cooX + xChange, cooY + yChange].status = 0;
                board1[cooX + xChange, cooY + yChange].king = false;
                board1[desX, desY].status = player;
                board1[desX, desY].king = board1[cooX, cooY].king;
            }

            board1[cooX, cooY].king = false;
            board1[cooX, cooY].status = 0;
            if (player==1)
            {
                player1score++;
            }
            else
            {
                player1score++;
            }
        }
        private bool validCoordinates(int player, int cooX, int cooY) //Checks if the values input are within board dimensions.
        {
            bool error = false;

            if (board1[cooX, cooY].status == player)
            {
                return true;
            }

            return false;
        }
        private bool inBounds(int cooX, int cooY) //Checks if the values input are within board dimensions.
        {
            if (cooX > -1 && cooX < 8 && cooY > -1 && cooY < 8)
            {
                return true;
            }

            return false;
        }
        private bool validDestination (int cooX, int cooY, int desX, int desY, int player, bool inProgress)
        {
            bool king = board1[cooX,cooY].king;
            int xDistance = desX - cooX;
            int yDistance = desY - cooY;
            int xChange = -1;
            int enemy=1;
            
            if (player==1)
            {
                enemy = 2;
            }
            if (desX > cooX)//left or right
            {
                xChange = 1;
            }

            if (xDistance < 0)
            {
                xDistance = xDistance * -1;
            }

            if (yDistance < 0)
            {
                yDistance = yDistance * -1;
            }

            if (inProgress && yDistance !=2)
            {
                return false;
            }

            if (board1[cooX, cooY].status != player)//must move own piece
            {
                return false;
            }

            if (board1[desX, desY].status != 0)//must move onto empty square
            {
                return false;
            }

            if (desX == cooX || desY == cooY)//coordinates must move
            {
                return false;
            }

            if (xDistance != yDistance || xDistance >2)//check for diagonal
            {
                return false;
            }



            if (!king)
            {
                if ( player==1 )
                {
                    if (desY > cooY+2 || desY < cooY+1 || desX > cooX + 2 || desX < cooX - 2) //check only moves by one
                    {
                        return false;
                    }
                    else
                    {
                        if (desY==cooY+2)//taking
                        {
                            if (board1[cooX+xChange,cooY].status != enemy)//check taking enemy
                            {
                                return false;
                            }
                            return true;
                        }
                        
                    }
                }
                else
                {
                    if (desY > cooY - 1 || desY < cooY - 2 || desX > cooX + 2 || desX < cooX - 2)
                    {
                        return false;
                    }
                    else
                    {
                        if (desY==cooY-2)//taking
                        {
                            if (board1[cooX + xChange, cooY].status != enemy)//check taking enemy
                            {
                                return false;
                            }
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (xDistance == 2)//taking
                {
                    if (board1[cooX + xChange, cooY].status != enemy)//check taking enemy
                    {
                        return false;
                    }
                }
            }

           if (!inProgress)
           {
               if (checkForPossibleTakes(player))
                {
                    return false;
                }
           }
            return true;
        }
        public bool checkForLocalTakes(int cooX, int cooY)
        {
            int player = board1[cooX, cooY].status;
            bool king = board1[cooX, cooY].king;
            int enemy = 1;

            if (player==1)
            {
                enemy = 2;
            }

            //up
            if ((player == 1 && king) || player == 2)
            {
                if (cooX > 0 && cooY > 0)//and left
                {
                    if (board1[cooX-1, cooY-1].status == enemy)
                    {
                        return true;
                    }
                }
                else if (cooX < 7 && cooY > 0)//and right
                {
                    if (board1[cooX + 1, cooY - 1].status == enemy)
                    {
                        return true;
                    }
                }
            }
            else if (player == 1 || (player==2 && king))//down
            {
                if (cooX > 0 && cooY < 7 )//and left
                {
                    if (board1[cooX - 1, cooY + 1].status == enemy)
                    {
                        return true;
                    }
                }
                else if (cooX < 7 && cooY < 7)//and right
                {
                    if (board1[cooX + 1, cooY + 1].status == enemy)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool checkForPossibleTakes(int player)
        {
            for (int i = 0; i < dimensions; i++)
            {
                for (int j = 0; j < dimensions; j++)
                {
                    if (board1[i,j].status==player)
                    {
                        if (checkForLocalTakes(i, j))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}