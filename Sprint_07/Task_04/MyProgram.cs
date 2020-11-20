using System;
using System.Linq;

namespace Sprint_07.Task_04
{
    internal class MyProgram
    {
        public static string GetWord(string input, string seed)
            => (input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Where(str => str.Length > seed.Length)
                    .OrderBy(str => str.Length).LastOrDefault() ?? seed)
                .SkipWhile(letter => letter != 'a')
                .Aggregate("", (firstLetter, secondLetter) => firstLetter + secondLetter);
    }
}
