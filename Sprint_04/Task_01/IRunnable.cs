using System;

namespace Sprint_04.Task_01
{
    internal interface IRunnable
    {
        public int MaxSpeed => 0;

        public void Run() 
            => Console.WriteLine("I can run up to {0} kilometers per hour!", MaxSpeed);
    }
}
