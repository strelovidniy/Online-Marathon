using System;
using System.Linq;

namespace Sprint_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            String[] names = {"Jack", "Mark", "Harry", "May"};
            var querry = names.Select(n => new {Name = n, Length = n.Length});
            foreach (var name in querry)
            {
                Console.WriteLine(name);
            }

            
        }
    }
}
