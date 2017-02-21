namespace Owl.References.Parsers
{
    /// <summary>
    /// Contract for parsing references into objects
    /// </summary>
    public interface ReferenceParser
    {
        /// <summary>
        /// Parses a book reference into a book object
        /// </summary>
        /// <param name="reference">The reference string</param>
        /// <returns>
        /// A book object with the data from the reference string
        /// </returns>
        Book Book(string reference);
    }
}