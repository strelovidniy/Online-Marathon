using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_02.Task_04
{
    class Bishop : ChessFigure
    {
        public override void Move()
        {
            Console.WriteLine("Moves by a diagonal!");
        }
    }
}
