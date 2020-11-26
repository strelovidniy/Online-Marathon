using System;
using System.Threading.Tasks;

namespace Sprint_09.Task_01
{
    public class CalcAsync
    {
        public static async void PrintSeqAsync(int n)
            => await Task.Run(() => Console.WriteLine("Seq[{0}] = {1}", n, Calc.Seq(n)));
    }
}
