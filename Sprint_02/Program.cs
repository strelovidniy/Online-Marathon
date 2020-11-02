using System;

namespace Sprint_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Employee("Roman", DateTime.Parse("02.11.2012"));

            Console.WriteLine(a.Experience());
        }
    }
}
