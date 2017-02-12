using System;
using System.Collections.Generic;

namespace Owl.References
{
    public class Book
    {
        public Book()
        {

        }

        public static Book CreateFull(string title, IEnumerable<Author> authors, int edition, string placeOfPublication,
            string publisher, int yearOfPublication, string isbn, int startPage = -1, int endPage = -1)
        {
            return null;
        }

        public Guid Id { get; set; }

        public string Title { get; private set; }

        public IEnumerable<Author> Author { get; set; }

        public int Edition { get; private set; }

        public string PlaceOfPublication { get; private set; }

        public string Publisher { get; private set; }

        public int YearOfPublication { get; private set; }

        public int StartPage { get; private set; }

        public int EndPage { get; private set; }

        public string ISBN { get; private set; }
    }
}