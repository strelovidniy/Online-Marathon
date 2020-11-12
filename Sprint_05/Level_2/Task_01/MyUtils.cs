using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_2.Task_01
{
    class MyUtils
    {
        public static bool ListDictionaryCompare(List<string> list, Dictionary<string, string> dictionary)
        {
            var distinctsList = list.Distinct().ToArray();
            var distinctsDictionary = dictionary.Values.Distinct().ToArray();

            if (distinctsDictionary.Length != distinctsList.Length)
            {
                return false;
            }

            Array.Sort(distinctsList);
            Array.Sort(distinctsDictionary);

            for (int i = 0; i < distinctsList.Length; ++i)
            {
                if (distinctsList[i] != distinctsDictionary[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
