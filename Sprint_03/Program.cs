using System;
using System.Collections.Generic;
using Sprint_03.Task_04;

namespace Sprint_03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.ToString<int>());
            numbers.IncreaseWith(20);
            Console.WriteLine(numbers.ToString<int>());
        }
    }
}
