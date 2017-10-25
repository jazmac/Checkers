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

        public Moves()
        {
            cooX = 0;
            cooY = 0;
            desX = 0;
            desY = 0;
            Close = false;
        }

        public bool Close { get; set; }
    }
}
