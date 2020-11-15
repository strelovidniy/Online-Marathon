using System;

namespace Sprint_02.Task_04
{
    internal class Bishop : ChessFigure
    {
        public override void Move() 
            => Console.WriteLine("Moves by a diagonal!");
    }
}
