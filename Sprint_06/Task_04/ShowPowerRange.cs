using System;
using System.Collections.Generic;

namespace Sprint_06.Task_04
{
    internal class ShowPowerRange
    {
        public static IEnumerable<int> PowerRanger(int degree, int start, int finish)
        {
            if(start > finish || start < 0 || finish < 0)
            {
                yield break;
            }
            else if (degree == 0)
            {
                yield return 1;
            }
            else
            {
                for (var i = 0; i <= finish; ++i)
                {
                    var value = (int)Math.Pow(i, degree);

                    if (value >= start && value <= finish)
                    {
                        yield return value;
                    }
                }
            }
        }
    }
}
