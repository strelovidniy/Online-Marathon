using System;
using Sprint_02.Task_01;

namespace Sprint_02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new Employee("Roman", DateTime.Parse("02.11.2012"));

            Console.WriteLine(a.Experience());
        }
    }
}
