using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_03.Task_05
{
    class EventProgram
    {
        public event EventHandler Show;

        public EventProgram()
        {
            Show += Dog;
            Show += Cat;
            Show += Mouse;
            Show += Elephant;

            Show?.Invoke(this, null);
        }

        static void Dog(object sender, EventArgs e)
        {
            Console.WriteLine("Dog");
        }

        static void Cat(object sender, EventArgs e)
        {
            Console.WriteLine("Cat");
        }

        static void Mouse(object sender, EventArgs e)
        {
            Console.WriteLine("Mouse");
        }

        static void Elephant(object sender, EventArgs e)
        {
            Console.WriteLine("Elephant");
        }
    }
}
