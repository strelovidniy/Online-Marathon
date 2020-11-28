using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint_09.Task_05
{
    internal class CalcAsync
    {
        public static async void PrintSpecificSeqElementsAsync(int[] numbers)
        {
            Task jobTask = null;
            
            try
            {
                jobTask = Task.WhenAll(
                    numbers.Select(
                            number => Task.Run(
                                () => Console.WriteLine("Seq[{0}] = {1}", number, Calc.Seq(number)))));

                await jobTask;
            }
            catch (Exception)
            {
                foreach (var innerException in jobTask.Exception.InnerExceptions)
                {
                    Console.WriteLine("Inner exception: {0}", innerException.Message);
                }
            }
        }
    }
}
