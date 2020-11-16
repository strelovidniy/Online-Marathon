using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_1.Task_03
{
    internal class MyProgram
    {
        public static void SearchKeys(Dictionary<string, string> persons)
            => persons.Keys.ToList().ForEach(Console.WriteLine);

        public static void SearchValues(Dictionary<string, string> persons)
            => persons.Values.ToList().ForEach(Console.WriteLine);

        public static void SearchAdmin(Dictionary<string, string> persons, string adminValue = "Admin")
            => persons.ToLookup(item => item.Value, item => item.Key)[adminValue]
                .ToList()
                .ForEach(item => Console.WriteLine("{0} {1}", item, adminValue));
    }
}
