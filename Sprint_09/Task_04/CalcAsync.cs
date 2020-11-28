using System;
using System.Collections.Generic;

namespace Sprint_09.Task_04
{
    internal class CalcAsync
    {
        public static async IAsyncEnumerable<(int, int)> SeqStreamAsync(int n)
        {
            for (var i = 1; i <= n; ++i)
            {
                yield return (i, Calc.Seq(i));
            }
        }

        public static async void PrintStream(IAsyncEnumerable<(int, int)> stream)
        {
            await foreach (var (item1, item2) in stream)
            {
                Console.WriteLine("Seq[{0}] = {1}", item1, item2);
            }
        }
    }
}
