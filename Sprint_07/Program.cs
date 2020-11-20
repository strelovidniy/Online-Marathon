using System;
using System.Text.Json;
using Sprint_07.Task_05;

namespace Sprint_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var w = new Worker("Anna", 700, new Department("Mechanics", 1, new Worker("Tom", 600, null)));

            Console.WriteLine(JsonSerializer.Serialize(w));
        }
    }
}
