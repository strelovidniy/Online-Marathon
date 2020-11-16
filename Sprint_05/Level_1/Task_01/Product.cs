using System;
using System.Linq;

namespace Sprint_05.Level_1.Task_01
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }


        public static void TotalPrice(ILookup<string, Product> lookup)
        {
            foreach (var group in lookup)
            {
                foreach (var item in group)
                {
                    Console.WriteLine("{0} {1}", item.Name, item.Price);
                }

                Console.WriteLine("{0} {1}", group.Key, group.Sum(x => x.Price));
            }
        }
    }
}
