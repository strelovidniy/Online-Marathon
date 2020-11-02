using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_02
{
    class SportCar : Car
    {
        private int maxSpeed;

        public SportCar(string mark, int prodYear, int maxSpeed)
        {
            base.mark = mark;
            base.prodYear = prodYear;
            this.maxSpeed = maxSpeed;
        }

        public new void ShowInfo()
        {
            Console.WriteLine("Mark: {0},\nProducted in {1}\nMaximum speed is {2}", mark, prodYear, maxSpeed);
        }
    }
}
