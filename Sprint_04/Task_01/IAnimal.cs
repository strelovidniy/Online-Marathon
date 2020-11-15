using System;

namespace Sprint_04.Task_01
{
    internal interface IAnimal
    {
        public int LifeDuration => 0;

        public void Voice() 
            => Console.WriteLine("No voice!");

        public void ShowInfo() 
            => Console.WriteLine("I am a {0} and I live approximately {1} years.", this.GetType(), LifeDuration);
    }
}
