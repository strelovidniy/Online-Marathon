using System;

namespace Sprint_10.Task_06
{
    public class Cat : IMoving, IEating, IBasking
    {
        public string Food { get; set; } = "milk";

        public void Eat()
            => Console.WriteLine($"Oh! My {Food}!");

        public void Move()
            => Console.WriteLine("I can jump!");

        public void Bask()
            => Console.WriteLine("Mrrr-Mrrr-Mrrr...");
    }
}
