using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_2.Task_01
{
    class MyUtils
    {
        public static bool ListDictionaryCompare(List<string> list, Dictionary<string, string> dictionary)
            => list.All(dictionary.Values.Contains) && dictionary.Values.All(list.Contains);
    }
}
