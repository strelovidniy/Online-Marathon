using System;

namespace Sprint_06.Task_01
{
    public class OutputUtils
    {
        public static void ExitOutput(CircleOfChildren circle, int syllables, int childrenCount = 0)
        {
            foreach (var child in circle.GetChildrenInOrder(syllables, childrenCount))
            {
                Console.Write("{0} ", child);
            }
        }
    }
}
