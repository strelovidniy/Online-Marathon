using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint_04.Task_03
{
    class Example
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
