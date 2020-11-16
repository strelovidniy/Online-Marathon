using System.Collections.Generic;

namespace Sprint_06.Task_03
{
    internal class ShowPower
    {
        public static IEnumerable<double> SuperPower(int number, int degree)
        {
            var result = 1d;

            if (degree == 0)
            {
                yield return 1;
            }
            if (degree > 0)
            {
                for (var i = 1; i <= degree; ++i)
                {
                    yield return result *= number;
                }
            }
            if (degree < 0)
            {
                for (var i = -1; i >= degree; --i)
                {
                    if (number != 0)
                    {
                        yield return result /= number;
                    }
                }
            }
        }
    }
}
