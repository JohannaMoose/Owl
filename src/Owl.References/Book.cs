using System;
using System.Collections.Generic;
using System.Linq;

namespace Owl.References
{
    /// <summary>
    /// Class representing a book reference 
    /// </summary>
    public class Book : IEquatable<Book>
    {
        /// <summary>
        /// Create a new instance of the book class
        /// </summary>
        public Book()
        {
            Id = Guid.NewGuid();
            Title = ""; 
            Authors = new Author[0];
            Edition = -1;
            PlaceOfPublication = "";
            Publisher = "";
            YearOfPublication = -1;
            StartPage = -1;
            EndPage = -1;
            ISBN = ""; 
        }

        /// <summary>
        /// Creates a full Bokk reference
        /// </summary>
        /// <param name="title">The title of the book</param>
        /// <param name="authors">A list of the authors of the book</param>
        /// <param name="edition">The edition of the bokk</param>
        /// <param name="placeOfPublication">The name of the place the book is published</param>
        /// <param name="publisher">The name of the publisher of the book</param>
        /// <param name="yearOfPublication">The year the book was published</param>
        /// <param name="isbn">The ISBN number of the book, defaults to empty</param>
        /// <param name="startPage">The first page the reference is for</param>
        /// <param name="endPage">The last page the reference is for</param>
        /// <returns></returns>
        public static Book CreateFull(string title, IEnumerable<Author> authors, int edition, string placeOfPublication,
            string publisher, int yearOfPublication, string isbn = null, int startPage = -1, int endPage = -1)
        {
            return new Book
            {
                Title = title,
                Authors = authors,
                Edition =  edition,
                PlaceOfPublication = placeOfPublication,
                Publisher = publisher,
                YearOfPublication = yearOfPublication,
                StartPage = startPage,
                EndPage = endPage,
                ISBN = isbn
            };
        }

        /// <summary>
        /// Get the system id of the book reference
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Get the title of the book, empty string if not provided
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Get a list of authors of the book, an empty list if not provided
        /// </summary>
        public IEnumerable<Author> Authors { get; private set; }

        /// <summary>
        /// Get the edition of the book the reference is for, -1 if not provided
        /// </summary>
        public int Edition { get; private set; }

        /// <summary>
        /// Get the name of the place the book is published, empty string if not provided
        /// </summary>
        public string PlaceOfPublication { get; private set; }

        /// <summary>
        /// Get the name of the publisher of the book, empty string if not provided
        /// </summary>
        public string Publisher { get; private set; }

        /// <summary>
        /// Get the year the book is published, -1 if not provided
        /// </summary>
        public int YearOfPublication { get; private set; }

        /// <summary>
        /// Get the pagenumber of the first page the reference pertains to, -1 if no page is given
        /// </summary>
        public int StartPage { get; private set; }

        /// <summary>
        /// Get the pagenumber of the last page the reference pertains to, -1 if no page is given
        /// </summary>
        public int EndPage { get; private set; }

        /// <summary>
        /// Get the ISBN number of the book, empty string if not given
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Title, other.Title) &&
                Authors.OrderBy(t => t).SequenceEqual(other.Authors.OrderBy(t => t)) && 
                Edition == other.Edition && 
                string.Equals(PlaceOfPublication, other.PlaceOfPublication) && 
                string.Equals(Publisher, other.Publisher) && 
                YearOfPublication == other.YearOfPublication && 
                StartPage == other.StartPage && 
                EndPage == other.EndPage && 
                string.Equals(ISBN, other.ISBN);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Book) obj);
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Title?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Authors?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ Edition;
                hashCode = (hashCode * 397) ^ (PlaceOfPublication?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Publisher?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ YearOfPublication;
                hashCode = (hashCode * 397) ^ StartPage;
                hashCode = (hashCode * 397) ^ EndPage;
                hashCode = (hashCode * 397) ^ (ISBN?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}