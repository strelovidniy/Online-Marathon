using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_07.Task_03
{
    internal class MyProgram
    {
        public static int ProductWithCondition(List<int> integers, Func<int, bool> predicate)
            => integers.Where(predicate).Aggregate(1, (left, right) => left * right);
    }
}
