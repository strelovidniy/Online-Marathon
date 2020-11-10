using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_02
{
    class Dog : IAnimal
    {
        public string Name { get; set; }

        public void Feed()
        {
            Console.WriteLine("I eat meat");
        }

        public void Voice()
        {
            Console.WriteLine("Woof");
        }
    }
}
