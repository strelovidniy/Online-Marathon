using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_06.Task_02
{
    public class MyUtils
    {
        public static List<Book> GetFiltered(IEnumerable<Book> books, Predicate<Book> filter)
            => books.ToList().FindAll(filter);
    }
}
