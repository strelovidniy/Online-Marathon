using System.Collections.Generic;

namespace Sprint_03.Task_04
{
    public static class IEnumerableExtensions
    {
        public static string ToString<T>(this List<int> list)
        {
            var tempS = "";

            list.ForEach(element => tempS += $"{element}, ");

            return $"[{tempS.Substring(0, tempS.Length - 2)}]";
        }
    }
}
