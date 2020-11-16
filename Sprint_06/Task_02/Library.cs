﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_06.Task_02
{
    public class Library
    {
        public IEnumerable<Book> Books { get; }
        public Predicate<Book> Filter { get; set; }

        public Library(IEnumerable<Book> books)
        {
            Books = books;
            Filter = book => true;
        }

        public IEnumerator<Book> GetEnumerator()
            => Books.ToList().FindAll(Filter).GetEnumerator();
    }
}
