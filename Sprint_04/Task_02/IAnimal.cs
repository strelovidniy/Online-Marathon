using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_02
{
    interface IAnimal
    {
        public string Name { get; set; }
        public void Voice();
        public void Feed();
    }
}
