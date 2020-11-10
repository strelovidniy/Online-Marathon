using System;

namespace Sprint_04.Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var room1 = new Room<Rectangle>();
            var room2 = room1.Clone() as Room<Rectangle>;

            Console.WriteLine();

        }
    }
}
