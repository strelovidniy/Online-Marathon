using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_2.Task_03
{
    internal class MyProgram
    {
        public static Dictionary<string, List<string>> ReverseNotebook(Dictionary<string, string> phonesToNames)
            => phonesToNames.GroupBy(pair => pair.Value ?? "")
                            .ToDictionary(pair => pair.Key, pair => pair.Select(keyValuePair => keyValuePair.Key).ToList());
    }
}
