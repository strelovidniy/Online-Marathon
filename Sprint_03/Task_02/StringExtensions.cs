using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_03.Task_02
{
    public static class StringExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!', '-', ';', ':', ',' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
