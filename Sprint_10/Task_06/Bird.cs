using System;

namespace Sprint_10.Task_06
{
    public class Bird : IFlyable, IEating, IMoving
    {
        public virtual string Food { get; set; } = "corn";

        public void Fly()
            => Console.WriteLine("I believe, I can fly");

        public virtual void Eat()
            => Console.WriteLine($"Oh! My {Food}!");

        public virtual void Move()
            => Console.WriteLine("I can jump!");
    }
}
