using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_01.Task_04
{
    public abstract class CloseableResource
    {
        public void Close()
        {
            Console.WriteLine("Closing resource");
        }
    }
}
