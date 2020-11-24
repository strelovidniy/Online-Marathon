using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Sprint_08.Task_02
{
    internal class MainThreadProgram
    {
        public static (Thread, Thread) Calculator()
        {
            var productThread = new Thread(Product);
            var sumThread = new Thread(Sum);

            productThread.Start();
            sumThread.Start();

            return (sumThread, productThread);
        }

        public static void Product()
        {
            Thread.Sleep(10000);

            Console.WriteLine(
                "Product is: {0}", new List<int>
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10
                }.Aggregate(1, (left, right) => left * right));
        }


        public static void Sum()
        {
            var numbers = new List<int>();

            Console.WriteLine("Enter the 1st number:");
            var number = int.Parse(Console.ReadLine());

            numbers.Add(number);

            Console.WriteLine("Enter the 2nd number:");
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);

            Console.WriteLine("Enter the 3th number:");
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);

            Console.WriteLine("Enter the 4th number:");
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);

            Console.WriteLine("Enter the 5th number:");
            number = int.Parse(Console.ReadLine());

            numbers.Add(number);

            Console.WriteLine("Sum is: {0}", numbers.Sum());
        }
    }
}
