using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_01
{
    interface IRunnable
    {
        public int MaxSpeed
        {
            get => 0;
        }

        public void Run()
        {
            Console.WriteLine("I can run up to {0} kilometers per hour!", MaxSpeed);
        }
    }
}
