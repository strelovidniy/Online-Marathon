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
            await foreach (var valueTuple in stream)
            {
                Console.WriteLine("Seq[{0}] = {1}", valueTuple.Item1, valueTuple.Item2);
            }
        }
    }
}
