using System;
using System.Threading;
using Sprint_09.Task_05;

namespace Sprint_09
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] numbers = { -3, -5, -12, 0 };
            CalcAsync.PrintSpecificSeqElementsAsync(numbers);
            Thread.Sleep(1000);
        }
    }
}
