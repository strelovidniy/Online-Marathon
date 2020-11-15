using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_2.Task_02
{
    internal class MyProgram
    {
        public static Lookup<string, string> CreateNotebook(Dictionary<string, string> phonesToNames)
            => (Lookup<string, string>)phonesToNames.ToLookup(pair => pair.Value ?? "", pair => pair.Key);
    }
}
