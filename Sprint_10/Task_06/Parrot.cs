using System;

namespace Sprint_10.Task_06
{
    public class Parrot : Bird, IBasking, IKryaking
    {
        public override string Food { get; set; } = "seeds and fruits";
        
        public void Bask()
            => Console.WriteLine("Chuh-Chuh-Chuh...");
        
        public void Krya()
            => Console.WriteLine("Krya-Krya-Krya...");

        public override void Eat()
            => Console.WriteLine($"Oh! My {Food}!");
    }
}
