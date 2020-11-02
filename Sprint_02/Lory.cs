using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_02
{
    class Lory : Car
    {
        private double loadCapacity;

        public Lory(string mark, int prodYear, double loadCapacity)
        {
            base.mark = mark;
            base.prodYear = prodYear;
            this.loadCapacity = loadCapacity;
        }

        public new void ShowInfo()
        {
            Console.WriteLine("Mark: {0},\nProducted in {1}\nThe load capacity is {2}", mark, prodYear, loadCapacity);
        }
    }
}
