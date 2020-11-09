using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_01
{
    interface IAnimal
    {
        public int LifeDuration
        {
            get => 0;
        }

        public void Voice()
        {
            Console.WriteLine("No voice!");
        }

        public void ShowInfo()
        {
            Console.WriteLine("I am a {0} and I live approximately {1} years.", this.GetType(), LifeDuration);
        }
    }
}
