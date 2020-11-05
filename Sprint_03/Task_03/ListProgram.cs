using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_03.Task_03
{
    class ListProgram
    {
        public delegate bool FindAll(int element);

        public static List<int> ListWithPositive(List<int> list)
            => list.FindAll(element => element > 0 && element <= 10);
    }
}
