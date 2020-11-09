using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_01
{
    class Eagle : IAnimal, IFlyable
    {
        public int MaxHeight { get; set; }

        public int LifeDuration { get; set; }
    }
}
