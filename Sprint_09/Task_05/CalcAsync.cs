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

            var tasksList = numbers
                .Select(number => Task.Run(() => Console.WriteLine("Seq[{0}] = {1}", number, Calc.Seq(number))))
                .ToList();

            try
            {
                jobTask = Task.WhenAll(tasksList);
                await jobTask;
            }
            catch (Exception ex)
            {
                foreach (var innerException in jobTask.Exception.InnerExceptions)
                {
                    Console.WriteLine("Inner exception: {0}", innerException.Message);
                }
            }
        }
    }
}
