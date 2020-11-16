using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_06.Task_02
{
    public sealed class MyEnumerator : IEnumerator<Book>
    {
        private int _currentIndex = -1;
        private List<Book> _books;

        public MyEnumerator(IEnumerable<Book> books, Predicate<Book> predicate)
            =>_books = books.ToList() ?? new List<Book>();
        
        public MyEnumerator()
            => _books = new List<Book>();

        public bool MoveNext()
            => ++_currentIndex < _books.Count;

        public void Reset()
            => _currentIndex = -1;

        public Book Current => _books[_currentIndex];

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
