using System.Collections;

namespace Sprint_06.Task_02
{
    public class Book : IEnumerable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public Book(string title, string author, int pageCount)
        {
            Title = title;
            Author = author;
            PageCount = pageCount;
        }

        public IEnumerator GetEnumerator()
            => new MyEnumerator();
    }
}
