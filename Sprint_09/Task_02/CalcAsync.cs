using System;
using System.Threading.Tasks;

namespace Sprint_09.Task_02
{
    public static class CalcAsync
    {
        public static async Task TaskPrintSeqAsync(int n)
            => await Task.Run(() => Console.WriteLine("Seq[{0}] = {1}", n, Calc.Seq(n)));

        public static async void TrackStatus(this Task task)
        {
            var status = TaskStatus.Created;

            while (status != TaskStatus.RanToCompletion && status != TaskStatus.Faulted)
            {
                task.PrintStatusIfChanged(ref status);
            }
        }

        public static void PrintStatusIfChanged(this Task task, ref TaskStatus oldStatus)
        {
            if (task.Status != oldStatus)
            {
                Console.WriteLine(task.Status);
                oldStatus = task.Status;
            }
        }
    }
}
