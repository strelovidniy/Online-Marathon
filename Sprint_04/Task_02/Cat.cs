using System;

namespace Sprint_04.Task_02
{
    internal class Cat : IAnimal
    {
        public string Name { get; set; }

        public void Feed() 
            => Console.WriteLine("I eat mice");

        public void Voice() 
            => Console.WriteLine("Mew");
    }
}
