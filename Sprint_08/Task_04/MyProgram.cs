using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_08.Task_04
{
    internal class MyProgram
    {
        public static void Counter(int number)
        {
            var operations = new List<Action<int>>
            {
                FactorialCounter,
                FibonaciCounter
            };

            operations.AsParallel().ForAll(operation => operation.Invoke(number));
        }

        private static void FibonaciCounter(int number)
        {
            var fibo = new List<int>{0, 1};

            for (var i = 2; i <= number; i++)
            {
                fibo.Add(fibo[i - 1] + fibo[i - 2]);
            }
            
            Console.WriteLine("Fibbonaci number is: {0}", fibo[number]);
        }

        private static void FactorialCounter(int number)
        {
            var result = 1;

            for (var i = 1; i <= number; i++)
            {
                result *= i;
            }

            Console.WriteLine("Factorial is: {0}", result);
        }
    }
}
