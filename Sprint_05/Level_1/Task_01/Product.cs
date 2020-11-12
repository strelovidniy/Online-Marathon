using System;
using System.Linq;

namespace Sprint_05.Level_1.Task_01
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }


        public static void TotalPrice(ILookup<string, Product> lookup)
        {
            string group = "";
            decimal sum = 0;

            foreach (var productgroup in lookup)
            {
                foreach (var product in productgroup)
                {
                    Console.WriteLine("{0} {1}", product.Name, product.Price);
                    group = product.Category;
                    sum += product.Price;
                }

                Console.WriteLine("{0} {1}", group, sum);
                sum = 0;
            }
        }
    }
}
