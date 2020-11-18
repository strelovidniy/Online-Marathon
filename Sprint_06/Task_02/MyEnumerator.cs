using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_06.Task_02
{
    public sealed class MyEnumerator : IEnumerator<Book>
    {
        private int currentIndex = -1;
        private readonly List<Book> books;

        public MyEnumerator(IEnumerable<Book> books, Predicate<Book> filter)
            => this.books = books.ToList().FindAll(filter);
        
        public MyEnumerator()
            => books = new List<Book>();

        public bool MoveNext()
            => ++currentIndex < books.Count;

        public void Reset()
            => currentIndex = -1;

        public Book Current => books[currentIndex];

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
