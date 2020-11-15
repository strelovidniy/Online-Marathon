using System;

namespace Sprint_04.Task_01
{
    internal interface IFlyable
    {
        public int MaxHeight => 0;

        public void Fly() 
            => Console.WriteLine("I can fly at {0} meters height!", MaxHeight);
    }
}
