using System;
using System.Linq;

namespace Sprint_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] names = {"Jack", "Mark", "Harry", "May"};
            var query = names.Select(n => new {Name = n, Length = n.Length});
            foreach (var name in query)
            {
                Console.WriteLine(name);
            }

            
        }
    }
}
