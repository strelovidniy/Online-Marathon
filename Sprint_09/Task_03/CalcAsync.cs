using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprint_09.Task_03
{
    internal class CalcAsync
    {
        public static async Task<int> SeqAsync(int n)
            => Calc.Seq(n);

        public static async void PrintSeqElementsConsequentlyAsync(int quant)
        {
            for (var i = 1; i <= quant; i++)
            {
                await Task.Run(() => Console.WriteLine("Seq[{0}] = {1}", i, SeqAsync(i).Result));

                Task.FromResult(GetSeqAsyncTasks(quant));
            }
        }

        public static async void PrintSeqElementsInParallelAsync(int quant)
        {
            var tasks = GetSeqAsyncTasks(quant);
            
            for (var i = 0; i < tasks.Length; i++)
            {
                await Task.Run(() => Console.WriteLine("Seq[{0}] = {1}", i + 1, tasks[i].Result));
            }
        }

        public static Task<int>[] GetSeqAsyncTasks(int n)
        {
            var tasks = new Task<int>[n];

            for (var i = 1; i <= n; i++)
            {
                tasks[i - 1] = SeqAsync(i);
            }

            return tasks;
        }
    }
}
