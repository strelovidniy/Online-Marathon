using System;

namespace Sprint_02.Task_02
{
    internal abstract class Car
    {
        internal string mark;
        internal int prodYear;

        public new void ShowInfo() 
            => Console.WriteLine("Mark: {0},\nProducted in {1}", mark, prodYear);
    }
}
