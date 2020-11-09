using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_01
{
    interface IFlyable
    {
        public int MaxHeight
        {
            get => 0;
        }

        public void Fly()
        {
            Console.WriteLine("I can fly at {0} meters height!", MaxHeight);
        }
    }
}
