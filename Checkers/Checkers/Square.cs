using System;

namespace ConsoleApp1
{
    public class Square
    {
        public int status;
        public Boolean king;
        public Square()
        {

            status = 0;
            king = false;
        }

        public char getIcon()
        {
            if (status == 0)
            {
                return ' ';
            }

            if (king)
            {
                if (status == 1)
                {
                    return 'X';
                }
                else 
                {
                    return 'O';
                }
            }
            else
            {
                if (status == 1)
                {
                    return 'x';
                }
                else
                {
                    return 'o';
                }
            }
        }
    }
}