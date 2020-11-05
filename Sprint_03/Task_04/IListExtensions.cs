using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint_03.Task_04
{
    public static class IListExtensions
    {
        public static void IncreaseWith(this List<int> list, int a)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i] += a;
            }
        }
    }
}
