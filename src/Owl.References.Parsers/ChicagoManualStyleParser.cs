using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Owl.References.Parsers
{
    /// <summary>
    /// Reference Parser for Chicago Manual Style 16th edition
    /// </summary>
    public class ChicagoManualStyleParser : ReferenceParser
    {
        /// <summary>
        /// Creates a new instance of the ChicagoManualStyleParser class
        /// </summary>
        public ChicagoManualStyleParser() { }

        /// <summary>
        /// Parses a book reference into a book object
        /// </summary>
        /// <param name="reference">The reference string</param>
        /// <returns>
        /// A book object with the data from the reference string
        /// </returns>
        public Book Book(string reference)
        {
            var author = getAuthors(ref reference);
            var title = getTitle(ref reference);
            var edition = getEdition(ref reference);
            var placeOfPubliction = getPlaceOfPublication(ref reference);
            var publisher = getPublisher(ref reference);
            var publicationYear = getYearOfPublication(ref reference);

            return References.Book.CreateFull(title, new List<Author> {author}, edition, placeOfPubliction, publisher, publicationYear);
        }

        private static string getTitle(ref string reference)
        {
            var title = reference.Substring(0, reference.IndexOf(".", StringComparison.Ordinal));
            reference = reference.Remove(0, title.Length + 2);
            return title;
        }

        private static int getEdition(ref string reference)
        {
            var edition = 1;
            if (reference.IndexOf(".", StringComparison.Ordinal) >= reference.IndexOf(":", StringComparison.Ordinal))
                return edition;

            var editionString = reference.Substring(0, reference.IndexOf(".", StringComparison.Ordinal));
            reference = reference.Remove(0, editionString.Length + 2);
            edition = Convert.ToInt32(Regex.Match(editionString, @"(^[0-9]*)").Value);

            return edition;
        }

        private static string getPlaceOfPublication(ref string reference)
        {
            var placeOfPubliction = reference.Substring(0, reference.IndexOf(":", StringComparison.Ordinal));
            reference = reference.Remove(0, placeOfPubliction.Length + 2);
            return placeOfPubliction;
        }

        private static string getPublisher(ref string reference)
        {
            var publisher = reference.Substring(0, reference.IndexOf(",", StringComparison.Ordinal));
            reference = reference.Remove(0, publisher.Length + 2);
            return publisher;
        }

        private static int getYearOfPublication(ref string reference)
        {
            var publicationYear = reference.Substring(0, reference.IndexOf(".", StringComparison.Ordinal));
            reference = reference.Remove(0, publicationYear.Length + 1);
            return Convert.ToInt32(publicationYear);
        }

        private static Author getAuthors(ref string reference)
        {
            var authorString = reference.Substring(0, reference.IndexOf(".", StringComparison.Ordinal));
            var authorParts = authorString.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            reference = reference.Remove(0, authorString.Length + 2);
            return new Author(authorParts[0], authorParts[1]);
        }
    }
}