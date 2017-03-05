using System;
using System.Collections.Generic;
using System.Linq;

namespace Owl.References
{
    /// <summary>
    /// Class representing an author or ap erson
    /// </summary>
    public class Author : IEquatable<Author>
    {
        /// <summary>
        /// Creates a new instance of the Authors class
        /// </summary>
        /// <param name="lastName">The last name of the author</param>
        /// <param name="firstName">The first name of the author</param>
        /// <param name="middleNames">Possible middle names of the author, ordered</param>
        public Author(string lastName, string firstName,
            params string[] middleNames)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleNames = middleNames;
        }

        /// <summary>
        /// Get the first name of the author
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Get the middle names of the author, ordered
        /// </summary>
        public IEnumerable<string> MiddleNames { get; private set; }

        /// <summary>
        /// Get the last name of the author
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            return Equals(obj as Author);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Author other)
        {
            return other != null &&
                   string.Equals(FirstName, other.FirstName) &&
                   sameMiddleNames(other) &&
                   string.Equals(LastName, other.LastName);
        }

        private bool sameMiddleNames(Author other)
        {
            for (var i = 0; i < MiddleNames.Count(); i++)
            {
                if (!MiddleNames.ElementAt(i).Equals(other.MiddleNames.ElementAt(i)))
                    return false;
            }
            return true;
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = FirstName?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (MiddleNames?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (LastName?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
