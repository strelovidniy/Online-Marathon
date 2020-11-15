using System;

namespace Sprint_04.Task_03
{
    internal class Example
    {
        public static void Do()
        {
            var doc1 = new ColouredDocument("Document1");
            Console.WriteLine(doc1.Name);
            doc1.Rename("Document2");
            Console.WriteLine(doc1.Name);
        }
    }
}
