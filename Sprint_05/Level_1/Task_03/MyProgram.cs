using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_05.Level_1.Task_03
{
    internal class MyProgram
    {
        public static void SearchKeys(Dictionary<string, string> persons)
            => Write(persons.Keys.ToList());

        public static void SearchValues(Dictionary<string, string> persons)
            => Write(persons.Values.ToList());

        public static void SearchAdmin(Dictionary<string, string> persons)
        { 
            foreach (var person in persons)
            {
                if (person.Value == "Admin")
                {
                    Console.WriteLine("{0} {1}", person.Key, person.Value);
                }
            }
        }

        public static void Write(List<string> elements)
            => elements.ForEach(x => Console.WriteLine(x));
    }
}
