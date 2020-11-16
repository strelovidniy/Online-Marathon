using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_1.Task_02
{
    internal class MyProgram
    {
        public static void Position(List<int> numbers)
        {
            var positions = new List<int>();

            for (var i = 0; i <= numbers.LastIndexOf(5); ++i)
            {
                if (numbers[i] == 5)
                {
                    positions.Add(i + 1);
                }
            }

            Write(positions);
        }

        public static void Remove(List<int> numbers)
            => Write(numbers.FindAll(x => x < 20));

        public static void Insert(List<int> numbers)
        {
            numbers.Insert(2, -5);
            numbers.Insert(5, -6);
            numbers.Insert(7, -7);

            Write(numbers);
        }

        public static void Sort(List<int> numbers)
        {
            numbers.Sort();
            Write(numbers);
        }

        public static void Write(List<int> numbers)
            => numbers.ForEach(Console.WriteLine);
    }
}
