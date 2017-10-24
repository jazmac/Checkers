using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Board
    {
        static void Main(string[] args)
        {
            int i;
            int j;
            int remainder;

            for (i = 1; i <= 8; i++)
            {
                if (i % 2 == 0)
                {
                    remainder = 1;
                }

                else
                {
                    remainder = 0;
                }

                for (j = 1; j <= 8; j++)
                {
                    if (j % 2 == remainder)
                    {
                        Console.Write(" X ");
                    }

                    else
                    {
                        Console.Write(" O ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
