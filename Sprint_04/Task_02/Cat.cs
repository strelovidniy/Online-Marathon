using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_02
{
    class Cat : IAnimal
    {
        public string Name { get; set; }

        public void Feed()
        {
            Console.WriteLine("I eat mice");
        }

        public void Voice()
        {
            Console.WriteLine("Mew");
        }
    }
}
