using System;

namespace Sprint_04.Task_02
{
    internal class Dog : IAnimal
    {
        public string Name { get; set; }

        public void Feed() 
            => Console.WriteLine("I eat meat");

        public void Voice() 
            => Console.WriteLine("Woof");
    }
}
