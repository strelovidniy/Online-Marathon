using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_01
{
    class Cat : IAnimal, IRunnable
    {
        public int MaxSpeed { get; set; }
        public int LifeDuration { get; set; }

        public void Voice()
        {
            Console.WriteLine("Meow!");
        }
    }
}
