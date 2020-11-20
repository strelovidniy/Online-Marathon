using System;
using System.Linq;

namespace Sprint_07.Task_02
{
    internal class MyProgram
    {
        public static double EvaluateAggregate
        (
            double[] inputData, 
            Func<double, double, double> aggregate, 
            Func<double, int, bool> predicate
        )
            => inputData.Where(predicate).Aggregate(aggregate);
    }
}
