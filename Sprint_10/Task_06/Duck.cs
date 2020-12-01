using System;

namespace Sprint_10.Task_06
{
    public class Duck : Bird, IKryaking
    {
        public void Krya()
            => Console.WriteLine("Krya-Krya!");

        public override void Eat()
            => Console.WriteLine($"Oh! My {Food}!");

        public override void Move()
            => Console.WriteLine("I can swimm!");
    }
}
