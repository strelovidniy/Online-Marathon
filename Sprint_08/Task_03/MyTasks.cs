using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sprint_08.Task_03
{
    internal class MyTasks
    {
        public static void Tasks()
        {
            var sequenceNumbers = new List<int>();
            
            var tasks = new List<Task>
            {
                new Task(() =>
                    {
                        sequenceNumbers.AddRange(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                        Console.WriteLine("Calculated!");
                    }),
                new Task(() =>
                    {
                        sequenceNumbers.ForEach(Console.WriteLine);
                        Console.WriteLine("Bye!");

                    }),
                new Task(() =>
                    {
                        Thread.Sleep(2000);
                        sequenceNumbers.Select(i => i * i).ToList().ForEach(Console.WriteLine);
                        Console.WriteLine("Bye!");
                    })
            };

            tasks.ForEach(task =>
            {
                task.Start();
                task.Wait();
            });

            Console.WriteLine("Main done!");
        }
    }
}